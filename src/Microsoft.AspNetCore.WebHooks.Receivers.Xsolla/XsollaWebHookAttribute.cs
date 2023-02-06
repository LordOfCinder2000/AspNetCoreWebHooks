using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.AspNetCore.WebHooks.Properties;

namespace Microsoft.AspNetCore.WebHooks 
{
    public class XsollaWebHookAttribute : WebHookAttribute, IApiResponseMetadataProvider //, IWebHookEventSelectorMetadata
    {
        private static readonly ProducesAttribute Produces = new ProducesAttribute("application/json");

        //private string _eventName;

        public XsollaWebHookAttribute()
            : base(XsollaConstants.ReceiverName)
        {
        }

        //public string EventName
        //{
        //    get
        //    {
        //        return _eventName;
        //    }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            throw new ArgumentException(Resources.General_ArgumentCannotBeNullOrEmpty, nameof(value));
        //        }

        //        _eventName = value;
        //    }

        //}

        Type IApiResponseMetadataProvider.Type => Produces.Type;

        int IApiResponseMetadataProvider.StatusCode => Produces.StatusCode;

        void IApiResponseMetadataProvider.SetContentTypes(MediaTypeCollection contentTypes)
            => Produces.SetContentTypes(contentTypes);
    }
}