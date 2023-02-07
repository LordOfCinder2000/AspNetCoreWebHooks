using Microsoft.AspNetCore.WebHooks.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.AspNetCore.WebHooks
{
    [JsonObject(Title = "error")]
    public class XsollaError
    {
        private XsollaErrorCodeType _code;

        private string _message;

        public XsollaError(XsollaErrorCodeType code)
        {
            if (!Enum.IsDefined(typeof(XsollaErrorCodeType), code))
            {
                var message = string.Format(
                     CultureInfo.CurrentCulture,
                     Resources.General_InvalidEnumValue,
                     typeof(XsollaErrorCodeType),
                     code);
                throw new ArgumentException(message, nameof(code));
            }

            _code = code;
            _message = GetMessageByCode(code);
        }

        [JsonProperty("code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public XsollaErrorCodeType Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (Enum.IsDefined(typeof(XsollaErrorCodeType), value))
                {
                    var message = string.Format(
                         CultureInfo.CurrentCulture,
                         Resources.General_InvalidEnumValue,
                         typeof(XsollaErrorCodeType),
                         value);
                    throw new ArgumentException(message, nameof(value));
                }

                _code = value;
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

        private static string GetMessageByCode(XsollaErrorCodeType code)
        {
            switch (code)
            {
                case XsollaErrorCodeType.INVALID_USER:
                    return Resources.Invalid_User;

                case XsollaErrorCodeType.INVALID_PARAMETER:
                    return Resources.Invalid_Parameter;

                case XsollaErrorCodeType.INVALID_SIGNATURE:
                    return Resources.Invalid_Signature;

                case XsollaErrorCodeType.INCORRECT_AMOUNT:
                    return Resources.Incorrect_Amount;

                case XsollaErrorCodeType.INCORRECT_INVOICE:
                    return Resources.Incorrect_Invoice;

                default:
                    return "Unknown error code";
            }
        }
    }
}
