using System;

namespace Skclusive.Core.Component
{
    public class Executor : IExecutor
    {
        private IDisposable Disposable { set; get; }

        private Func<IDisposable> Execution { set; get; }

        public Executor(Func<IDisposable> execution)
        {
            Execution = execution;
        }

        public void Dispose()
        {
            if (Disposable == null)
            {
                throw new ObjectDisposedException(typeof(ActionDisposable).Name);
            }

            Disposable.Dispose();

            Disposable = null;
        }

        public void Execute()
        {
            Disposable = Execution.Invoke();
        }
    }
}
