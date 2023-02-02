using System;
using Microsoft.AspNetCore.WebHooks.Metadata;

namespace Microsoft.AspNetCore.WebHooks 
{
    public class XsollaWebHookAttribute : WebHookAttribute, IWebHookEventFromBodyMetadata
    {
        public XsollaWebHookAttribute()
            : base(XsollaConstants.ReceiverName)
        {
        }

        public bool AllowMissing => throw new NotImplementedException();

        public string BodyPropertyPath => throw new NotImplementedException();

        public bool IsApplicable(string receiverName)
        {
            throw new NotImplementedException();
        }
    }
}