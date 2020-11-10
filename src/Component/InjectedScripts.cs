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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddAttribute(1, "skclusive");

            if (RootRef != null)
            {
                builder.AddElementReferenceCapture(2, elementRef => RootRef.Current = elementRef);
            }

            var scripts = ScriptProviders.SelectMany(provider => provider.Scripts).Distinct();

            var content = new StringBuilder();

            foreach (var script in scripts)
            {
                var instance = Activator.CreateInstance(script);
                if (instance is ScriptBase _script)
                {
                    content.AppendLine(_script.GetScript());
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