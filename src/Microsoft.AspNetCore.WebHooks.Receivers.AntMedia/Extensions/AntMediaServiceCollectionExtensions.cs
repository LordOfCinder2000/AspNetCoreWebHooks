using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class AntMediaServiceCollectionExtensions
    {
        public static IServiceCollection AddAntMediaWebHooks(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            AntMediaServiceCollectionSetup.AddAntMediaServices(services);

            return services
                .AddWebHooks();
        }
    }
}