using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XsollaServiceCollectionExtensions
    {
        public static IServiceCollection AddXsollaWebHooks(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            XsollaServiceCollectionSetup.AddXsollaServices(services);

            return services
                .AddWebHooks();
        }
    }
}