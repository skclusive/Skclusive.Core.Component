using System;

namespace Skclusive.Core.Component
{
    public class ActionDisposable : IDisposable
    {
        private Action Disposer { get; set; }

        public ActionDisposable(Action disposer)
        {
            _ = disposer ?? throw new ArgumentNullException(nameof(disposer));

            Disposer = disposer;
        }

        public void Dispose()
        {
            if (Disposer == null)
            {
                throw new ObjectDisposedException(typeof(ActionDisposable).Name);
            }

            Disposer.Invoke();

            Disposer = null;
        }
    }
}
