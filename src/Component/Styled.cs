using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class Styled : StyleComponentBase, IDisposable
    {
        private static readonly ConcurrentDictionary<string, bool> RenderedState = new ConcurrentDictionary<string, bool>();

        /// <summary>
        /// unique name of the style
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// ChildContent which contains the style definitions
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // if (PlatformInfo.IsWebAssembly)
            // {
            //     ClientRenderTree(builder);
            // }
            // else
            {
                ServerRenderTree(builder);
            }
        }

        protected void ClientRenderTree(RenderTreeBuilder builder)
        {
            RenderedState.TryGetValue(Name, out var rendered);

            if (!rendered)
            {
                RenderStyleTree(builder);

                RenderedState.TryAdd(Name, true);
            }
        }

        protected void ServerRenderTree(RenderTreeBuilder builder)
        {
            RenderStyleTree(builder);
        }

        private void RenderStyleTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "style");
            builder.AddAttribute(1, "data-name", Name);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
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
