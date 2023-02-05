using Microsoft.AspNetCore.WebHooks.Filters;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.WebHooks.Metadata
{
    public class XsollaMetadata :
           WebHookMetadata, IWebHookFilterMetadata, IWebHookEventFromBodyMetadata
    {
        private readonly XsollaVerifySignatureFilter _verifySignatureFilter;

        public XsollaMetadata(
            XsollaVerifySignatureFilter verifySignatureFilter
            )
            : base(XsollaConstants.ReceiverName)
        {
            _verifySignatureFilter = verifySignatureFilter;
        }

        public override WebHookBodyType BodyType => WebHookBodyType.Json;

        public bool AllowMissing => false;

        public string BodyPropertyPath => XsollaConstants.EventBodyPropertyPath;

        public void AddFilters(WebHookFilterMetadataContext context)
        {
            context.Results.Add(_verifySignatureFilter);
        }
    }
}