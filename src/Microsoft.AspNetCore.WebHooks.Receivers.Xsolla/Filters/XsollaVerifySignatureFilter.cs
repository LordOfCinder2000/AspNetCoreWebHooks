using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.WebHooks.Filters
{
    public class XsollaVerifySignatureFilter : WebHookVerifySignatureFilter, IAsyncResourceFilter
    {
        public XsollaVerifySignatureFilter(
            IConfiguration configuration,
            IHostingEnvironment webHostEnvironment,
            ILoggerFactory loggerFactory)
            : base(configuration, webHostEnvironment, loggerFactory)
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

                var expectedHash = FromHex(header, XsollaConstants.SignatureHeaderName);
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
    }
}