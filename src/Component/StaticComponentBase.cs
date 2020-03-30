using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class StaticComponentBase : IComponent
    {
        private RenderFragment _renderFragment;
        private RenderHandle _renderHandle;
        protected bool _hasNeverRendered = true;

        /// <summary>
        /// Constructs an instance of <see cref="PureComponentBase"/>.
        /// </summary>
        public StaticComponentBase()
        {
            _renderFragment = builder =>
            {
                _hasNeverRendered = false;
                BuildRenderTree(builder);
            };
        }

        protected virtual void BuildRenderTree(RenderTreeBuilder builder)
        {
        }

        void IComponent.Attach(RenderHandle renderHandle)
        {
            // This implicitly means a PureComponentBase can only be associated with a single
            // renderer. That's the only use case we have right now. If there was ever a need,
            // a component could hold a collection of render handles.
            if (_renderHandle.IsInitialized)
            {
                throw new InvalidOperationException($"The render handle is already set. Cannot initialize a {nameof(StaticComponentBase)} more than once.");
            }

            _renderHandle = renderHandle;
        }

        public virtual Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            if (_hasNeverRendered)
            {
                _renderHandle.Render(_renderFragment);
            }
            return Task.CompletedTask;
        }
    }
}
