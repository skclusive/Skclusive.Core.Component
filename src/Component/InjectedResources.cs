using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class InjectedResources : PureComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenComponent<InjectedStyles>(1);
            builder.CloseComponent();
            builder.OpenComponent<InjectedScripts>(2);
            builder.CloseComponent();
        }
    }
}