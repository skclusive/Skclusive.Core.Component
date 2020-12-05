using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class InjectedStyles : PureComponentBase
    {
        [Parameter]
        public IReference RootRef { set; get; }

        [Inject]
        public IRenderContext RenderContext { set; get; }

        [Inject]
        public IEnumerable<IStyleTypeProvider> StyleProviders { set; get; } = Enumerable.Empty<IStyleTypeProvider>();

        /// <summary>
        /// Constructs an instance of <see cref="InjectedStyles"/>.
        /// </summary>
        public InjectedStyles() : base(disableBinding: true, disableConfigurer: true)
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "style");
            builder.AddAttribute(1, "skclusive", "");

            if (RootRef != null)
            {
                builder.AddElementReferenceCapture(2, elementRef => RootRef.Current = elementRef);
            }

            var providers = StyleProviders.Distinct().OrderByDescending(provider => provider.Priority.HasValue).ThenBy(provider => provider.Priority);

            var index = 2;
            foreach (var provider in providers)
            {
                var priority = $"{Environment.NewLine}/* priority: {provider.Priority?.ToString() ?? "default"} source: {provider.GetType().Name} */";

                if (RenderContext.IsServer && RenderContext.IsPreRendering)
                {
                    builder.AddContent(index++, new MarkupString(priority));
                }
                else
                {
                    builder.AddContent(index++, priority);
                }

                foreach (var style in provider.Styles)
                {
                    builder.OpenComponent(index++, style);
                    builder.CloseComponent();
                }
            }

            builder.CloseElement();
        }
    }
}