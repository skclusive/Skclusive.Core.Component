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

        [Parameter]
        public IReference RootRef { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "style");
            builder.AddAttribute(1, "skclusive");

            if (RootRef != null)
            {
                builder.AddElementReferenceCapture(2, elementRef => RootRef.Current = elementRef);
            }

            var styles = StyleProviders.SelectMany(provider => provider.Styles).Distinct();

            foreach (var style in styles.Select((type, index) => (type, index: index + 3)))
            {
                builder.OpenComponent(style.index, style.type);
                builder.CloseComponent();
            }

            builder.CloseElement();
        }
    }
}