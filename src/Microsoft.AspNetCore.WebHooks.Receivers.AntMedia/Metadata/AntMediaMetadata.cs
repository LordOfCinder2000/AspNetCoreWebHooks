using Microsoft.AspNetCore.WebHooks.Filters;

namespace Microsoft.AspNetCore.WebHooks.Metadata
{
    public class AntMediaMetadata :
           WebHookMetadata, IWebHookEventFromBodyMetadata, IWebHookFilterMetadata
    {
        private readonly AntMediaRequestFilter _antMediaRequestFilter;

        public AntMediaMetadata(AntMediaRequestFilter antMediaRequestFilter)
            : base(AntMediaConstants.ReceiverName)
        {
            _antMediaRequestFilter = antMediaRequestFilter;
        }

        public override WebHookBodyType BodyType => WebHookBodyType.Form;

        public bool AllowMissing => false;

        public string BodyPropertyPath => AntMediaConstants.EventBodyPropertyPath;

        public void AddFilters(WebHookFilterMetadataContext context)
        {
            context.Results.Add(_antMediaRequestFilter);
        }
    }
}