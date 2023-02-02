namespace Microsoft.AspNetCore.WebHooks
{
    public class XsollaConstants
    {
        public static string ReceiverName => "xsolla";

        public static string NotificationTypePropertyName => "notification_type";

        public static int SecretKeyMinLength => 16;

        public static string SignatureHeaderKey => "Signature";

        public static string SignatureHeaderName => "Authorization";
    }
}

