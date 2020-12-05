using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Core.Component
{
    public class AuthenticationRouteView : PureComponentBase
    {
        private AuthenticationState currentAuthenticationState;

        private bool? isAuthenticated;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public Type RedirectType { set; get; }

        [Parameter]
        public Type DefaultLayout { set; get; }

        [Parameter]
        public RouteData RouteData { get; set; }

        /// <summary>
        /// Constructs an instance of <see cref="AuthenticationRouteView"/>.
        /// </summary>
        public AuthenticationRouteView() : this(disableBinding: true, disableConfigurer: true)
        {
        }

        /// <summary>
        /// Constructs an instance of <see cref="AuthenticationRouteView"/>.
        /// </summary>
        public AuthenticationRouteView(bool? disableBinding, bool? disableConfigurer) : base(disableBinding, disableConfigurer)
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            currentAuthenticationState = await AuthenticationState;

            isAuthenticated = currentAuthenticationState.User?.Identity?.IsAuthenticated;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var allowed =  ((isAuthenticated.HasValue && isAuthenticated.Value)
                || RouteData.PageType.GetCustomAttribute<AllowAnonymousAttribute>() != null);

            var routeData = allowed ? RouteData : new RouteData(RedirectType, RouteData.RouteValues);
            builder.OpenComponent<RouteView>(0);
            builder.AddAttribute(1, nameof(RouteView.RouteData), routeData);
            builder.AddAttribute(2, nameof(RouteView.DefaultLayout), DefaultLayout);
            builder.CloseComponent();
        }
    }
}