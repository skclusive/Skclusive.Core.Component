using System;
using System.Collections.Generic;

namespace Skclusive.Core.Component
{
    public interface IThemeService
    {
        Theme Current { get; }

        void ChangeTheme(Theme theme);

        event EventHandler<Theme> OnChange;
    }
}
