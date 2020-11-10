using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public interface IStyleTypeProvider
    {
        IEnumerable<Type> Styles { get; }
    }
}
