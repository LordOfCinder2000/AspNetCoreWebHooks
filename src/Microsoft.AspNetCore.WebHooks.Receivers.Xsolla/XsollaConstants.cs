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

        public static class ErrorCodes
        {
            public static string INVALID_USER = Resources.Invalid_User;

            public static string INVALID_PARAMETER = Resources.Invalid_Parameter;

            public static string INVALID_SIGNATURE = Resources.Invalid_Signature;

            public static string INCORRECT_AMOUNT = Resources.Incorrect_Amount;

            public static string INCORRECT_INVOICE = Resources.Incorrect_Invoice;
        }
    }
}

