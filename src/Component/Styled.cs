using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class Styled : StyleComponentBase
    {
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
            builder.OpenElement(0, "style");
            builder.AddAttribute(1, "data-name", Name);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
