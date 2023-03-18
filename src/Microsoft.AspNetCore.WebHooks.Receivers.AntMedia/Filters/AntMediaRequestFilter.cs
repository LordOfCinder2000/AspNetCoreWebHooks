using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.AspNetCore.WebHooks.Filters
{
    public class AntMediaRequestFilter : IResourceFilter, IWebHookReceiver, IOrderedFilter
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AntMediaRequestFilter(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<AntMediaRequestFilter>();
        }

        public string ReceiverName => AntMediaConstants.ReceiverName;

        public static int Order => WebHookPingRequestFilter.Order;

        int IOrderedFilter.Order => Order;

        public bool IsApplicable(string receiverName)
        {
            if (receiverName == null)
            {
                throw new ArgumentNullException(nameof(receiverName));
            }

            return string.Equals(ReceiverName, receiverName, StringComparison.OrdinalIgnoreCase);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
