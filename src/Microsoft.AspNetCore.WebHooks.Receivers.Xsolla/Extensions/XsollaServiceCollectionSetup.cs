using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class XsollaServiceCollectionSetup
    {
        public static void AddXsollaServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            WebHookMetadata.Register<XsollaMetadata>(services);
            services.TryAddSingleton<XsollaVerifySignatureFilter>();
        }
    }
}