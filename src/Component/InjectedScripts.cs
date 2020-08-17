using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class InjectedScripts : PureComponentBase
    {
        [Inject]
        public IEnumerable<IScriptTypeProvider> ScriptProviders { set; get; } = Enumerable.Empty<IScriptTypeProvider>();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var scripts = ScriptProviders.SelectMany(provider => provider.Scripts).Distinct();

            foreach (var script in scripts.Select((type, index) => (type, index)))
            {
                builder.OpenComponent(script.index, script.type);
                builder.CloseComponent();
            }
        }
    }
}