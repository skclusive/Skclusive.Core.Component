using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public abstract class ScriptComponentBase : StaticComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddMarkupContent(1, GetScript());
            builder.CloseElement();
        }

        protected abstract string GetScript();
    }
}
