using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public class ThemeComponentBase : CssComponentBase
    {
        [CascadingParameter]
        public IThemeContext ThemeContext { set; get; }

        public Theme Theme => ThemeContext.Theme;

        protected bool IsAuto => Theme == Theme.Auto;

        protected bool IsDark => Theme == Theme.Dark;

        protected bool IsLight => Theme == Theme.Light;
    }
}