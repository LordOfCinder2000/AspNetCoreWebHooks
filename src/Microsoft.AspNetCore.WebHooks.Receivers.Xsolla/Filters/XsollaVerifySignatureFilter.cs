using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebHooks.Properties;
using Microsoft.AspNetCore.WebHooks.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Microsoft.AspNetCore.WebHooks.Filters
{
    public class XsollaVerifySignatureFilter : WebHookVerifySignatureFilter, IAsyncResourceFilter
    {
        // Character that appears between the key and value in the signature header.
        private static readonly char[] PairSeparators = new[] { ' ' };

        public XsollaVerifySignatureFilter(
            IConfiguration configuration,
            IHostingEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory)
            : base(configuration, hostingEnvironment, loggerFactory)
        {
        }

        public override string ReceiverName => XsollaConstants.ReceiverName;

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            var request = context.HttpContext.Request;
            if (HttpMethods.IsPost(request.Method))
            {
                // 1. Confirm a secure connection.
                var errorResult = EnsureSecureConnection(ReceiverName, context.HttpContext.Request);
                if (errorResult != null)
                {
                    context.Result = errorResult;
                    return;
                }

                // 2. Get the expected hash from the signature header.
                var header = GetRequestHeader(request, XsollaConstants.SignatureHeaderName, out errorResult);
                if (errorResult != null)
                {
                    context.Result = errorResult;
                    return;
                }

                var values = new TrimmingTokenizer(header, PairSeparators);
                var enumerator = values.GetEnumerator();
                enumerator.MoveNext();
                var headerKey = enumerator.Current;
                if (values.Count != 2 ||
                    !StringSegment.Equals(
                        headerKey,
                        XsollaConstants.SignatureHeaderKey,
                        StringComparison.OrdinalIgnoreCase))
                {
                    Logger.LogWarning(
                        0,
                        $"Invalid '{XsollaConstants.SignatureHeaderName}' header value. Expecting a value of " +
                        $"'{XsollaConstants.SignatureHeaderKey} <value>'.");

                    var message = string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.SignatureFilter_BadHeaderValue,
                        XsollaConstants.SignatureHeaderName,
                        XsollaConstants.SignatureHeaderKey,
                        "<value>");
                    errorResult = new BadRequestObjectResult(message);

                    context.Result = errorResult;
                    return;
                }

                enumerator.MoveNext();
                var headerValue = enumerator.Current.Value;

                var expectedHash = FromHex(headerValue, XsollaConstants.SignatureHeaderName);
                if (expectedHash == null)
                {
                    context.Result = CreateBadHexEncodingResult(XsollaConstants.SignatureHeaderName);
                    return;
                }

                // 3. Get the configured secret key.
                var secretKey = GetSecretKey(ReceiverName, context.RouteData, XsollaConstants.SecretKeyMinLength);
                if (secretKey == null)
                {
                    context.Result = new NotFoundResult();
                    return;
                }

                var secret = Encoding.UTF8.GetBytes(secretKey);

                // 4. Get the actual hash of the request body.
                var actualHash = await ComputeRequestBodySha1HashAsync(request, secret);

                // 5. Verify that the actual hash matches the expected hash.
                if (!SecretEqual(expectedHash, actualHash))
                {
                    // Log about the issue and short-circuit remainder of the pipeline.
                    errorResult = CreateBadSignatureResult(XsollaConstants.SignatureHeaderName);

                    context.Result = errorResult;
                    return;
                }
            }

            await next();
        }

        protected override async Task<byte[]> ComputeRequestBodySha1HashAsync(
                HttpRequest request,
                byte[] secret,
                byte[] prefix,
                byte[] suffix)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (secret == null)
            {
                throw new ArgumentNullException(nameof(secret));
            }
            if (secret.Length == 0)
            {
                throw new ArgumentException(Resources.General_ArgumentCannotBeNullOrEmpty, nameof(secret));
            }

            await WebHookHttpRequestUtilities.PrepareRequestBody(request);

            using (var hasher = SHA1.Create())
            {
                try
                {
                    if (prefix != null && prefix.Length > 0)
                    {
                        hasher.TransformBlock(
                            prefix,
                            inputOffset: 0,
                            inputCount: prefix.Length,
                            outputBuffer: null,
                            outputOffset: 0);
                    }

                    // Split body into 4K chunks.
                    var buffer = new byte[4096];
                    var inputStream = request.Body;
                    int bytesRead;
                    while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        hasher.TransformBlock(
                            buffer,
                            inputOffset: 0,
                            inputCount: bytesRead,
                            outputBuffer: null,
                            outputOffset: 0);
                    }

                    // Add secret after json body
                    suffix = secret;
                    if (suffix != null && suffix.Length > 0)
                    {
                        hasher.TransformBlock(
                            suffix,
                            inputOffset: 0,
                            inputCount: suffix.Length,
                            outputBuffer: null,
                            outputOffset: 0);
                    }

                    hasher.TransformFinalBlock(Array.Empty<byte>(), inputOffset: 0, inputCount: 0);

                    return hasher.Hash;
                }
                finally
                {
                    // Reset Position because JsonInputFormatter et cetera always start from current position.
                    request.Body.Seek(0L, SeekOrigin.Begin);
                }
            }
        }

        protected override IActionResult CreateBadSignatureResult(string signatureHeaderName)
        {
            if (signatureHeaderName == null)
            {
                throw new ArgumentNullException(nameof(signatureHeaderName));
            }

            Logger.LogWarning(
                404,
                "The WebHook signature provided by the '{HeaderName}' header field does not match the value " +
                "expected by the '{ReceiverName}' receiver. WebHook request is invalid.",
                signatureHeaderName,
                ReceiverName);

            return new BadRequestObjectResult(
                new XsollaErrorResponse
                {
                    Error = new XsollaError(nameof(XsollaConstants.ErrorCodes.INVALID_SIGNATURE))
                }
            );
        }
    }
}