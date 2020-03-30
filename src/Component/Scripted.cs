using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public abstract class Scripted : ScriptComponentBase, IDisposable
    {
        private static readonly ConcurrentDictionary<string, bool> RenderedState = new ConcurrentDictionary<string, bool>();

        private string Name { set; get; }

        protected Scripted(string name)
        {
            Name = name;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            RenderedState.TryGetValue(Name, out var rendered);

            if (!rendered)
            {
                base.BuildRenderTree(builder);

                RenderedState.TryAdd(Name, true);
            }
        }

        public void Dispose()
        {
            if (RenderedState.ContainsKey(Name))
            {
                RenderedState.TryRemove(Name, out var rendered);
            }
        }
    }
}
