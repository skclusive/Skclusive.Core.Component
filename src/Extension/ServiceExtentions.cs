using System;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;

namespace Skclusive.Core.Component
{
    public static class ServiceExtentions
    {
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