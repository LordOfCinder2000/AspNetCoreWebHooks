using Microsoft.AspNetCore.WebHooks.Filters;

namespace Microsoft.AspNetCore.WebHooks.Metadata
{
    public class XsollaMetadata :
           WebHookMetadata, IWebHookFilterMetadata
    {
        private readonly XsollaVerifySignatureFilter _verifySignatureFilter;

        public XsollaMetadata(XsollaVerifySignatureFilter verifySignatureFilter)
            : base(XsollaConstants.ReceiverName)
        {
            _verifySignatureFilter = verifySignatureFilter;
        }

        public override WebHookBodyType BodyType => WebHookBodyType.Json;

        public void AddFilters(WebHookFilterMetadataContext context)
        {
            context.Results.Add(_verifySignatureFilter);
        }
    }
}
