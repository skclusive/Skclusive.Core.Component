using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class ThemeContext : IThemeContext
    {
        public Theme Theme { get; private set; }

        public ThemeContext(Theme theme)
        {
            Theme = theme;
        }
    }
}
