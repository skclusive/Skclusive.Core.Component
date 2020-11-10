using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Core.Component
{
    public class CompositeDisposable : IDisposable
    {
        private List<IDisposable> Disposables { set; get; }

        public CompositeDisposable(IEnumerable<IDisposable> disposables)
        {
            Disposables = disposables.ToList();
        }

        public void Dispose()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }
    }
}