using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public interface IScriptTypeProvider
    {
        IEnumerable<Type> Scripts { get; }
    }
}
