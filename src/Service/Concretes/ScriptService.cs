using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Skclusive.Core.Component
{
    public class ScriptService : IScriptService
    {
        private IJSRuntime JSRuntime { get; }

        public ScriptService(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        private void ThrowIfPrerendering()
        {
            // if (true)
            // {
            //     throw new Exception("js-introp invoked during prerendering");
            // }
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeAsync<TValue>(identifier, args);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, TimeSpan timeout, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeAsync<TValue>(identifier, timeout, args);
        }

        public ValueTask InvokeVoidAsync(string identifier, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeVoidAsync(identifier, args);
        }

        public ValueTask InvokeVoidAsync(string identifier, CancellationToken cancellationToken, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeVoidAsync(identifier, cancellationToken, args);
        }

        public ValueTask InvokeVoidAsync(string identifier, TimeSpan timeout, params object[] args)
        {
            ThrowIfPrerendering();

            return JSRuntime.InvokeVoidAsync(identifier, timeout, args);
        }
    }
}
