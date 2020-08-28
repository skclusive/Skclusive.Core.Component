using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class InjectedStyles : PureComponentBase
    {
        [Inject]
        public IEnumerable<IStyleTypeProvider> StyleProviders { set; get; } = Enumerable.Empty<IStyleTypeProvider>();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "style");
            builder.AddAttribute(1, "skclusive");

            var styles = StyleProviders.SelectMany(provider => provider.Styles).Distinct();

            foreach (var style in styles.Select((type, index) => (type, index: index + 2)))
            {
                builder.OpenComponent(style.index, style.type);
                builder.CloseComponent();
            }

            builder.CloseElement();
        }
    }
}