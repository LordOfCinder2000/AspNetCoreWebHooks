using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XsollaMvcBuilderExtensions
    {
        public static IMvcBuilder AddXsollabWebHooks(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            XsollaServiceCollectionSetup.AddXsollaServices(builder.Services);

            return builder.AddWebHooks();
        }
    }
}