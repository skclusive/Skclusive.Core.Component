using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class CompositeAsyncDisposable : IAsyncDisposable
    {
        private List<IAsyncDisposable> Disposables { set; get; }

        public CompositeAsyncDisposable(IEnumerable<IAsyncDisposable> disposables)
        {
            Disposables = disposables.ToList();
        }

        public async ValueTask DisposeAsync()
        {
            await Task.WhenAll(Disposables.Select(d => d.DisposeAsync().AsTask()));
        }
    }
}