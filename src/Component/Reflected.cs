using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace Skclusive.Core.Component
{
    public class Reflected : EventComponentBase
    {
        [Parameter]
        public Type Type { set; get; }

        [Parameter]
        public bool AddAttributes { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Type != null)
            {
                builder.OpenComponent(1, Type);
                if (AddAttributes)
                {
                    builder.AddAttribute(2, "Class", _Class);
                    builder.AddAttribute(3, "Style", _Style);
                    if (Attributes?.Count > 0)
                    {
                        builder.AddMultipleAttributes(4, Attributes);
                    }
                }
                builder.CloseComponent();
            }
        }
    }
}
