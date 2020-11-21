using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    // Copyright (c) .NET Foundation. All rights reserved.
    // Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

    // IMPORTANT
    //
    // Many of these names are used in code generation. Keep these in sync with the code generation code
    // See: src/Microsoft.AspNetCore.Components.Razor.Extensions/ComponentsApi.cs

    // Most of the developer-facing component lifecycle concepts are encapsulated in this
    // base class. The core components rendering system doesn't know about them (it only knows
    // about IComponent). This gives us flexibility to change the lifecycle concepts easily,
    // or for developers to design their own lifecycles as different base classes.

    // TODO: When the component lifecycle design stabilizes, add proper unit tests for RenderComponentBase.

    /// <summary>
    /// Optional base class for components. Alternatively, components may
    /// implement <see cref="IComponent"/> directly.
    /// </summary>
    public class RenderComponentBase : PureComponentBase, IHandleAfterRender
    {
        protected bool _hasCalledOnAfterRender;

        protected bool Mounted { set; get; }

        protected bool FirstRender { private set; get; }

        /// <summary>
        /// Constructs an instance of <see cref="RenderComponentBase"/>.
        /// </summary>
        public RenderComponentBase() : this(disableBinding: null, disableConfigurer: null)
        {
        }

        /// <summary>
        /// Constructs an instance of <see cref="RenderComponentBase"/>.
        /// </summary>
        public RenderComponentBase(bool? disableBinding, bool? disableConfigurer) : base(disableBinding, disableConfigurer)
        {
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered.
        /// </summary>
        /// <param name="firstRender">
        /// Set to <c>true</c> if this is the first time <see cref="OnAfterRender(bool)"/> has been invoked
        /// on this component instance; otherwise <c>false</c>.
        /// </param>
        /// <remarks>
        /// The <see cref="OnAfterRender(bool)"/> and <see cref="OnAfterRenderAsync(bool)"/> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender"/> parameter to ensure that initialization work is only performed
        /// once.
        /// </remarks>
        protected virtual void OnAfterRender(bool firstRender)
        {
        }

        Task IHandleAfterRender.OnAfterRenderAsync()
        {
            var firstRender = !_hasCalledOnAfterRender;
            _hasCalledOnAfterRender |= true;

            OnAfterRender(firstRender);

            return OnAfterRenderAsync(firstRender);

            // Note that we don't call StateHasChanged to trigger a render after
            // handling this, because that would be an infinite loop. The only
            // reason we have OnAfterRenderAsync is so that the developer doesn't
            // have to use "async void" and do their own exception handling in
            // the case where they want to start an async task.
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered. Note that the component does
        /// not automatically re-render after the completion of any returned <see cref="Task"/>, because
        /// that would cause an infinite render loop.
        /// </summary>
        /// <param name="firstRender">
        /// Set to <c>true</c> if this is the first time <see cref="OnAfterRender(bool)"/> has been invoked
        /// on this component instance; otherwise <c>false</c>.
        /// </param>
        /// <returns>A <see cref="Task"/> representing any asynchronous operation.</returns>
        /// <remarks>
        /// The <see cref="OnAfterRender(bool)"/> and <see cref="OnAfterRenderAsync(bool)"/> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender"/> parameter to ensure that initialization work is only performed
        /// once.
        /// </remarks>
        protected virtual async Task OnAfterRenderAsync(bool firstRender)
        {
            FirstRender = firstRender;

            if (FirstRender)
            {
                Mounted = true;

                OnAfterMount();

                await OnAfterMountAsync();
            }
            else
            {
                OnAfterUpdate();

                await OnAfterUpdateAsync();
            }

            OnAfterRender();

            await OnAfterRenderAsync();
        }

        protected virtual void OnAfterMount()
        {
        }

        protected virtual Task OnAfterMountAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual void OnAfterUpdate()
        {
        }

        protected virtual Task OnAfterUpdateAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual void OnAfterRender()
        {
        }

        protected virtual Task OnAfterRenderAsync()
        {
            return Task.CompletedTask;
        }
    }
}
