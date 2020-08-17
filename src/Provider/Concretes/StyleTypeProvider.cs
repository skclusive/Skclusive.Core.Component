using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class StyleTypeProvider : IStyleTypeProvider
    {
        public IEnumerable<Type> Styles { get; }

        public StyleTypeProvider(params Type [] styles)
        {
            Styles = styles;
        }
    }
}
