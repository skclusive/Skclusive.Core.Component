using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Skclusive.Core.Component
{
    public static class ServiceExtentions
    {
        public static void TryAddTransientEnumerable<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            var serviceDescriptor = ServiceDescriptor.Transient<TService, TImplementation>();

            collection.TryAddEnumerable(serviceDescriptor);
        }

        public static void TryAddScopedEnumerable<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            var serviceDescriptor = ServiceDescriptor.Scoped<TService, TImplementation>();

            collection.TryAddEnumerable(serviceDescriptor);
        }

        public static void TryAddSingletonEnumerable<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            var serviceDescriptor = ServiceDescriptor.Singleton<TService, TImplementation>();

            collection.TryAddEnumerable(serviceDescriptor);
        }

        public static void TryAddStyleTypeProvider<TStyleTypeProvider>(this IServiceCollection collection) where TStyleTypeProvider : class, IStyleTypeProvider
        {
            collection.TryAddScopedEnumerable<IStyleTypeProvider, TStyleTypeProvider>();
        }

        public static void TryAddScriptTypeProvider<TScriptTypeProvider>(this IServiceCollection collection) where TScriptTypeProvider : class, IScriptTypeProvider
        {
            collection.TryAddScopedEnumerable<IScriptTypeProvider, TScriptTypeProvider>();
        }
    }
}