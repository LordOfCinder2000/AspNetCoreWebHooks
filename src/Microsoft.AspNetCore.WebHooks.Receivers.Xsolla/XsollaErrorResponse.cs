using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.WebHooks
{
    public class XsollaErrorResponse
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public XsollaError Error { get; set; }
    }
}
