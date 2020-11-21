using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class Condition : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { set; get; }

        [Parameter]
        public RenderFragment IfContent { set; get; }

        [Parameter]
        public RenderFragment ElseContent { set; get; }

        [Parameter]
        public bool If { set; get; }

        public Condition(bool? disableBinding = true, bool? disableConfigurer = null) : base(disableBinding, disableConfigurer)
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (If)
            {
                builder.AddContent(0, ChildContent ?? IfContent);
            }
            else
            {
                builder.AddContent(1, ElseContent);
            }
        }
    }
}
