namespace Microsoft.AspNetCore.WebHooks
{
    public class AntMediaWebHookAttribute : WebHookAttribute
    {
        public AntMediaWebHookAttribute()
            : base(AntMediaConstants.ReceiverName)
        {
        }
    }
}