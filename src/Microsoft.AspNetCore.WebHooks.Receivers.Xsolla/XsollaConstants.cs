using Microsoft.AspNetCore.WebHooks.Properties;

namespace Microsoft.AspNetCore.WebHooks
{
    public class XsollaConstants
    {
        public static string ReceiverName => "xsolla";

        public static string NotificationTypePropertyName => "notification_type";

        public static int SecretKeyMinLength => 16;

        public static string SignatureHeaderKey => "Signature";

        public static string SignatureHeaderName => "Authorization";

        public static string EventBodyPropertyPath => "$.notification_type";
    }

    public enum XsollaErrorCodeType
    {
        INVALID_PARAMETER = 1,

        INVALID_USER,

        INVALID_SIGNATURE,

        INCORRECT_AMOUNT,

        INCORRECT_INVOICE,
    }
}

