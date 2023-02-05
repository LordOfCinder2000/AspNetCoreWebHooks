using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.WebHooks
{
    [JsonObject(Title = "error")]
    public class XsollaError
    {
        private string _code;

        private string _message;

        public XsollaError(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            _code = code.ToUpperInvariant();
            _message = GetMessageByCode(code);
        }

        [JsonProperty("code")]
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _code = value.ToUpperInvariant();
            }
        }

        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _message = value.ToUpperInvariant();
            }
        }

        private static string GetMessageByCode(string code)
        {
            switch (code)
            {
                case nameof(XsollaConstants.ErrorCodes.INVALID_USER):
                    return XsollaConstants.ErrorCodes.INVALID_USER;
                case nameof(XsollaConstants.ErrorCodes.INVALID_PARAMETER):
                    return XsollaConstants.ErrorCodes.INVALID_PARAMETER;
                case nameof(XsollaConstants.ErrorCodes.INVALID_SIGNATURE):
                    return XsollaConstants.ErrorCodes.INVALID_SIGNATURE;
                case nameof(XsollaConstants.ErrorCodes.INCORRECT_AMOUNT):
                    return XsollaConstants.ErrorCodes.INCORRECT_AMOUNT;
                case nameof(XsollaConstants.ErrorCodes.INCORRECT_INVOICE):
                    return XsollaConstants.ErrorCodes.INCORRECT_INVOICE;
                default:
                    return "Unknown error code";
            }
        }
    }
}
