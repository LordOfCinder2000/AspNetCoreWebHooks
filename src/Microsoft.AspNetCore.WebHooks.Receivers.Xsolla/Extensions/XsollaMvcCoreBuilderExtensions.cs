using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XsollaMvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddGitHubWebHooks(this IMvcCoreBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            XsollaServiceCollectionSetup.AddXsollaServices(builder.Services);

            return builder
                .AddJsonFormatters()
                .AddWebHooks();
        }
    }
}
