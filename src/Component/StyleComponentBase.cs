using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public class StyleComponentBase : StaticComponentBase
    {
        protected readonly string media = "@media";

        protected readonly string keyframes = "@keyframes";

        protected readonly string webkitKeyframes = "@-webkit-keyframes";

        protected readonly string OpenCurly = "{";

        protected readonly string CloseCurly = "}";

        protected readonly string MediaSchemeLight = "@media (prefers-color-scheme: light)";

        protected readonly string MediaSchemeDark = "@media (prefers-color-scheme: dark)";
    }
}
