using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public class EventContextComponentBase : EventComponentBase
    {
        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IComponentContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference("ChildContextRef");

        /// <summary>
        /// Constructs an instance of <see cref="EventContextComponentBase"/>.
        /// </summary>
        public EventContextComponentBase() : this(selector: "")
        {
        }

        /// <summary>
        /// Constructs an instance of <see cref="EventContextComponentBase"/>.
        /// </summary>
        public EventContextComponentBase(string selector) : this(selector, disableBinding: null, disableConfigurer: null)
        {
        }

        /// <summary>
        /// Constructs an instance of <see cref="EventContextComponentBase"/>.
        /// </summary>
        public EventContextComponentBase(string selector, bool? disableBinding, bool? disableConfigurer) : base(selector, disableBinding, disableConfigurer)
        {
        }

        public bool HasContent => ChildContent != null;

        protected virtual IComponentContext Context => ContextBuilder().Build();

        protected virtual ComponentContextBuilder ContextBuilder()
        {
            return new ComponentContextBuilder()
           .WithClass(Class)
           .WithStyle(Style)
           .WithRefBack(ChildRef)
           .WithDisabled(Disabled);
        }
    }
}
