using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.WebHooks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace XsollaReceiver.Controllers
{
    public class XsollaController : ControllerBase
    {
        public XsollaController()
        {
        }


        [XsollaWebHook]
        public async Task<IActionResult> XsollaWebhookHandler(string @event, [FromBody] JObject data)
        {

            return Ok();
        }
    }
}
