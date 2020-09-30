using System;
using System.Collections.Generic;
using System.Reflection;

namespace Skclusive.Core.Component
{
    public class RouteAssemblyProvider : IRouteAssemblyProvider
    {
        public IEnumerable<Assembly> Assemblies { get; }

        public RouteAssemblyProvider(params Assembly [] assemblies)
        {
            Assemblies = assemblies;
        }
    }

    public class RouteAssemblyProvider<T> : RouteAssemblyProvider
    {
        public RouteAssemblyProvider() : base(typeof(T).Assembly)
        {
        }
    }
}
