using System;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class AsyncDisposable : IAsyncDisposable
    {
        private IDisposable Disposable { set; get; }

        public AsyncDisposable(IDisposable disposable)
        {
            Disposable = disposable;
        }

        public ValueTask DisposeAsync()
        {
            if (Disposable == null)
            {
                throw new ObjectDisposedException(typeof(AsyncDisposable).Name);
            }

            Disposable.Dispose();

            Disposable = null;

            return new ValueTask();
        }
    }
}