using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class AntMediaMvcBuilderExtensions
    {
        public static IMvcBuilder AddAntMediaWebHooks(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            AntMediaServiceCollectionSetup.AddAntMediaServices(builder.Services);

            return builder.AddWebHooks();
        }
    }
}