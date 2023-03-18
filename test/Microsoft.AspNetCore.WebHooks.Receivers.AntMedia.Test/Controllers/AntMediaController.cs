using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks;
using Newtonsoft.Json.Linq;

namespace AntMediaReceiver.Controllers;

public class AntMediaController : ControllerBase
{
    public AntMediaController()
    {
    }

    public class AntWebhook
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string StreamName { get; set; }
    }


    [AntMediaWebHook]
    public async Task<IActionResult> AntMediaWebHookHandler(string @event, [FromForm] AntWebhook data)
    {

        return Ok();
    }
}
