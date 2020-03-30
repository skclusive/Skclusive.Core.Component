using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Skclusive.Core.Component
{
    public static class CoreExtension
    {
        public static void TryAddCoreServices(this IServiceCollection services, ICoreConfig config)
        {
            services.TryAddSingleton<ICoreConfig>(config);
            services.TryAddScoped<IRenderContext>((sp) => new RenderContext(config.IsServer, config.IsPreRendering));
        }
    }
}
