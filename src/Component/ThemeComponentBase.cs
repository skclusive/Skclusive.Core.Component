using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public class ThemeComponentBase : CssComponentBase
    {
        [Parameter]
        public Theme Theme { set; get; } = Theme.Auto;

        protected bool IsAuto => Theme == Theme.Auto;

        protected bool IsDark => Theme == Theme.Dark;

        protected bool IsLight => Theme == Theme.Light;
    }
}