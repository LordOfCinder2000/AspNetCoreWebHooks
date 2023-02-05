using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class WebHookServiceCollectionExtensions
    {
        public static IServiceCollection AddWebHooks(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            WebHookServiceCollectionSetup.AddWebHookServices(services);

            return services;
        }
    }
}
