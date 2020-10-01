using System;
using System.Threading;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public interface IScriptService
    {
        ValueTask<TValue> InvokeAsync<TValue>(string identifier, params object[] args);

        ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, params object[] args);

        ValueTask<TValue> InvokeAsync<TValue>(string identifier, TimeSpan timeout, params object[] args);

        ValueTask InvokeVoidAsync(string identifier, params object[] args);

        ValueTask InvokeVoidAsync(string identifier, CancellationToken cancellationToken, params object[] args);

        ValueTask InvokeVoidAsync(string identifier, TimeSpan timeout, params object[] args);
    }
}