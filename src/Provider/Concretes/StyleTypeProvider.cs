using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class StyleTypeProvider : IStyleTypeProvider
    {
        public int? Priority { get; }

        public IEnumerable<Type> Styles { get; }

        public StyleTypeProvider(int? priority = null, params Type [] styles)
        {
            Priority = priority;

            Styles = styles;
        }

        public StyleTypeProvider(params Type [] styles) : this(priority: default, styles)
        {
        }
    }
}
