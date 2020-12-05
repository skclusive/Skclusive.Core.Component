using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public interface IScriptTypeProvider
    {
        int? Priority { get; }

        IEnumerable<Type> Scripts { get; }
    }
}
