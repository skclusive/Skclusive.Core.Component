﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Core.Component
{
    public class CssComponentBase : DisposableComponentBase
    {
        protected readonly string media = "@media";

        protected readonly string keyframes = "@keyframes";

        protected readonly string webkitKeyframes = "@-webkit-keyframes";

        protected readonly string OpenCurly = "{";

        protected readonly string CloseCurly = "}";

        protected readonly string MediaSchemeLight = "@media (prefers-color-scheme: light)";

        protected readonly string MediaSchemeDark = "@media (prefers-color-scheme: dark)";

        public virtual string Selector { get; set; }

        public string Stamp { get; }

        /// <summary>
        /// html <c>id</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public string Id { set; get; }

        /// <summary>
        /// html <c>role</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public virtual string Role { set; get; }

        /// <summary>
        /// html <c>tabIndex</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public int? TabIndex { set; get; }

        /// <summary>
        /// html <c>class</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public string Class { set; get; }

        /// <summary>
        /// html <c>style</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public string Style { set; get; }

        /// <summary>
        /// html <c>disabled</c> attribute used for the root node.
        /// </summary>
        [Parameter]
        public bool? Disabled { set; get; }

        /// <summary>
        /// specifies whether component class name generation could be overridable.
        /// </summary>
        [Parameter]
        public string Overridable { set; get; }

        /// <summary>
        /// captures unmatched attributes passed to the component.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Constructs an instance of <see cref="CssComponentBase"/>.
        /// </summary>
        public CssComponentBase(string selector = "", bool? disableBinding = true, bool? disableConfigurer = true) : base(disableBinding, disableConfigurer)
        {
            Stamp = GetType().Name + "_" + Guid.NewGuid().ToString();

            Selector = selector;
        }

        public override string ToString() => Stamp;

        protected virtual IComponentContext _Context => null;

        protected virtual string _ContextClass => _Context?.Class;

         protected virtual string _ContextStyle => _Context?.Style;

        protected virtual string _Style
        {
            get => CssUtil.ToStyle(Styles, Style, _ContextStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> Styles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _Class
        {
            get => CssUtil.ToClass(Selector, Overridable, Classes, Class, _ContextClass);
        }

        protected virtual string GetRootName()
        {
            return "Root";
        }

        protected virtual IEnumerable<string> Classes
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Selector))
                {
                    yield return GetRootName();

                    if (Disabled.HasValue && Disabled.Value)
                        yield return nameof(Disabled);
                }
            }
        }
    }
}
