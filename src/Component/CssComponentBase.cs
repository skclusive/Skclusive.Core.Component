using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Core.Component
{
    public class CssComponentBase : DisposableComponentBase
    {
        public virtual string Selector { get; set; }

        public string Stamp { get; }

        [Parameter]
        public string Id { set; get; }

        [Parameter]
        public virtual string Role { set; get; }

        [Parameter]
        public int? TabIndex { set; get; }

        [Parameter]
        public string Class { set; get; }

        [Parameter]
        public string Style { set; get; }

        [Parameter]
        public bool? Disabled { set; get; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        public CssComponentBase(string selector = "")
        {
            Stamp = GetType().Name + "_" + Guid.NewGuid().ToString();

            Selector = selector;
        }

        public override string ToString() => Stamp;

        public virtual string _Style
        {
            get => CssUtil.ToStyle(Styles, Style);
        }

        protected virtual IEnumerable<Tuple<string, object>> Styles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _Class
        {
            get => CssUtil.ToClass(Selector, Classes, Class);
        }

        protected virtual IEnumerable<string> Classes
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Selector))
                {
                    yield return "Root";

                    if (Disabled.HasValue && Disabled.Value)
                        yield return nameof(Disabled);
                }
            }
        }
    }
}
