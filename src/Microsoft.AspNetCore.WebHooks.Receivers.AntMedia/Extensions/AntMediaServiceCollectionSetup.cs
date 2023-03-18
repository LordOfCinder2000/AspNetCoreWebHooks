using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class AntMediaServiceCollectionSetup
    {
        public static void AddAntMediaServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            WebHookMetadata.Register<AntMediaMetadata>(services);
            services.TryAddSingleton<AntMediaRequestFilter>();
        }
    }
}