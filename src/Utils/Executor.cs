using System;

namespace Skclusive.Core.Component
{
    public class Executor : IExecutor
    {
        private IDisposable Disposable { set; get; }

        private bool disposed { set; get; } = false;

        private Func<IDisposable> Execution { set; get; }

        public Executor(Func<IDisposable> execution)
        {
            Execution = execution;
        }

        public void Dispose()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(typeof(ActionDisposable).Name);
            }

            Disposable?.Dispose();

            Disposable = null;

            disposed = true;
        }

        public void Execute()
        {
            Disposable = Execution.Invoke();
        }
    }
}
