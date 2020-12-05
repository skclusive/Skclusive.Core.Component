using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public interface IStyleTypeProvider
    {
        int? Priority { get; }

        IEnumerable<Type> Styles { get; }
    }
}
