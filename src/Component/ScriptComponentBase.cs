using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public abstract class ScriptComponentBase : StaticComponentBase
    {
        [Inject]
        public IRenderContext RenderContext { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var script = GetScript();
            var isServer = RenderContext.IsServer;
            var isPreRendering = RenderContext.IsPreRendering;

            builder.OpenElement(0, "script");
            if (isServer && isPreRendering)
            {
                builder.AddContent(1, new MarkupString(script));
            }
            else
            {
                builder.AddContent(2, script);
            }
            builder.CloseElement();
        }

        protected abstract string GetScript();
    }
}