using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class JavaScript : StaticComponentBase
    {
        [Parameter]
        public string Src { set; get; }

        [Parameter]
        public string Type { set; get; } = "text/javascript";

        [Parameter]
        public bool Async { set; get; }

        [Parameter]
        public bool Defer { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddAttribute(1, "src", Src);
            builder.AddAttribute(2, "type", Type);
            if (Async)
                builder.AddAttribute(3, "async", Async);
            if (Defer)
                builder.AddAttribute(4, "defer", Defer);
            builder.CloseElement();
        }
    }
}
