using System;
using System.Collections.Generic;
using System.Reflection;

namespace Skclusive.Core.Component
{
    public interface IRouteAssemblyProvider
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}
