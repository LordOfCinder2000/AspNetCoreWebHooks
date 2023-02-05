using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.WebHooks.Filters
{
    public class WebHookEventNameSelectorFilter : IAsyncResourceFilter, IOrderedFilter
    {
        private readonly ILogger _logger;
        private readonly IWebHookBodyTypeMetadataService _bodyTypeMetadata;
        private readonly IWebHookEventSelectorMetadata _eventSelectorMetadata;
        private readonly WebHookMetadataProvider _metadataProvider;

        public WebHookEventNameSelectorFilter(
            ILoggerFactory loggerFactory,
            IWebHookBodyTypeMetadataService bodyTypeMetadata,
            IWebHookEventSelectorMetadata eventSelectorMetadata) 
            : this(loggerFactory)
        {
            if (bodyTypeMetadata == null)
            {
                throw new ArgumentNullException(nameof(bodyTypeMetadata));
            }

            if (eventSelectorMetadata == null)
            {
                throw new ArgumentNullException(nameof(eventSelectorMetadata));
            }

            _bodyTypeMetadata = bodyTypeMetadata;
            _eventSelectorMetadata = eventSelectorMetadata;
        }

        public WebHookEventNameSelectorFilter(
            ILoggerFactory loggerFactory,
            WebHookMetadataProvider metadataProvider)
            : this(loggerFactory)
        {
            if (metadataProvider == null)
            {
                throw new ArgumentNullException(nameof(metadataProvider));
            }

            _metadataProvider = metadataProvider;
        }

        private WebHookEventNameSelectorFilter(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _logger = loggerFactory.CreateLogger<WebHookEventNameSelectorFilter>();
        }

        public static int Order => WebHookEventNameMapperFilter.Order + 10;

        int IOrderedFilter.Order => Order;

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            var routeData = context.RouteData;
            var bodyTypeMetadata = _bodyTypeMetadata;
            var eventSelectorMetadata = _eventSelectorMetadata;
            if (bodyTypeMetadata == null)
            {
                if (!routeData.TryGetWebHookReceiverName(out var receiverName))
                {
                    await next();
                    return;
                }

                bodyTypeMetadata = _metadataProvider.GetBodyTypeMetadata(receiverName);
                if (eventSelectorMetadata == null)
                {
                    await next();
                    return;
                }
            }
            var eventName = eventSelectorMetadata.EventName;
            if (eventName != null)
            {
                if (context.RouteData.TryGetWebHookEventNames(out var eventNames))
                {
                    if (eventNames.Any(name => string.Equals(eventName, name, StringComparison.OrdinalIgnoreCase)))
                    {
                        // Simple case. Request is for the expected event.
                        _logger.LogInformation(
                            "Receiver {ReceiverName} trigger webhooks event for: {EventName}!", 
                            _bodyTypeMetadata.ReceiverName, 
                            eventName
                        );
                        await next();
                    }
                }
            }

            return;
        }
    }
}
