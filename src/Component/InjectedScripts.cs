using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class InjectedScripts : PureComponentBase
    {
        [Parameter]
        public IReference RootRef { set; get; }

        [Inject]
        public IRenderContext RenderContext { set; get; }

        [Inject]
        public IEnumerable<IScriptTypeProvider> ScriptProviders { set; get; } = Enumerable.Empty<IScriptTypeProvider>();

        /// <summary>
        /// Constructs an instance of <see cref="InjectedScripts"/>.
        /// </summary>
        public InjectedScripts() : base(disableBinding: true, disableConfigurer: true)
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddAttribute(1, "skclusive", "");

            if (RootRef != null)
            {
                builder.AddElementReferenceCapture(2, elementRef => RootRef.Current = elementRef);
            }

            var providers = ScriptProviders.Distinct().OrderByDescending(provider => provider.Priority.HasValue).ThenBy(provider => provider.Priority);

            var content = new StringBuilder();

            foreach (var provider in providers)
            {
                content.AppendLine($"{Environment.NewLine}/* priority: {provider.Priority?.ToString() ?? "default"} source: {provider.GetType().Name} */");
                foreach (var script in provider.Scripts)
                {
                    var instance = Activator.CreateInstance(script);
                    if (instance is ScriptBase _script)
                    {
                        content.AppendLine(_script.GetScript());
                    }
                }
            }

            if (RenderContext.IsServer && RenderContext.IsPreRendering)
            {
                builder.AddContent(3, new MarkupString(content.ToString()));
            }
            else
            {
                builder.AddContent(4, content.ToString());
            }

            builder.CloseElement();
        }
    }
}