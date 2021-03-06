﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class Condition : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { set; get; }

        [Parameter]
        public RenderFragment IfContent { set; get; }

        [Parameter]
        public RenderFragment ElseContent { set; get; }

        [Parameter]
        public bool If { set; get; }

        /// <summary>
        /// Constructs an instance of <see cref="Condition"/>.
        /// </summary>
        public Condition() : this(disableBinding: true, disableConfigurer: null)
        {
        }

        /// <summary>
        /// Constructs an instance of <see cref="Condition"/>.
        /// </summary>
        public Condition(bool? disableBinding, bool? disableConfigurer) : base(disableBinding, disableConfigurer)
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (If)
            {
                builder.AddContent(0, ChildContent ?? IfContent);
            }
            else
            {
                builder.AddContent(1, ElseContent);
            }
        }
    }
}
