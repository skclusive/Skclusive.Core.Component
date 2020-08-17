using System;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class ActionAsyncDisposable : IAsyncDisposable
    {
        private Func<Task> Disposer { get; set; }

        public ActionAsyncDisposable(Func<Task> disposer)
        {
            _ = disposer ?? throw new ArgumentNullException(nameof(disposer));

            Disposer = disposer;
        }

        public async ValueTask DisposeAsync()
        {
            if (Disposer == null)
            {
                throw new ObjectDisposedException(typeof(ActionDisposable).Name);
            }

            await Disposer();

            Disposer = null;
        }
    }
}
