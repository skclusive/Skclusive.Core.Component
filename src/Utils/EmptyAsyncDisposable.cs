using System;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class EmptyAsyncDisposable : IAsyncDisposable
    {
        public static readonly IAsyncDisposable Empty = new EmptyAsyncDisposable();

        private EmptyAsyncDisposable()
        {
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask();
        }
    }
}