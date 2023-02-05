using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks;
using Newtonsoft.Json.Linq;

namespace XsollaReceiver.Controllers
{
    public class XsollaController : ControllerBase
    {
        [XsollaWebHook(EventName = "order_paid")]
        public async Task<IActionResult> XsollaWebhookHandler([FromBody] JObject data)
        {
            var payload = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            return Ok();
        }
    }
}
