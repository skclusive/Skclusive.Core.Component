using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public class ThemeService : IThemeService
    {
        public Theme Current { get; set; }

        public ThemeService(Theme current)
        {
            Current = current;
        }

        public void ChangeTheme(Theme theme)
        {
            Current = theme;

            var onChange = OnChange;

            if (onChange != null)
            {
                onChange(this, Current);
            }
        }

        public event EventHandler<Theme> OnChange;
    }
}
