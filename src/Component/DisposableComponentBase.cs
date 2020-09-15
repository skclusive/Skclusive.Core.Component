using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class DisposableComponentBase : RenderComponentBase, IAsyncDisposable
    {
        private List<IDisposable> Disposables { get; set; } = new List<IDisposable>();

        private List<IDisposable> PropChangeDisposables { get; set; } = new List<IDisposable>();

        private List<IExecutor> PostStateChange { get; set; } = new List<IExecutor>();


        protected void AddStateChange(IExecutor executor)
        {
            PostStateChange.Add(executor);
        }

        protected IDisposable StateHasChanged(IExecutor executor, bool immediate = true)
        {
            AddStateChange(executor);

            if (immediate)
            {
                StateHasChanged();
            }

            IDisposable disposable = new ActionDisposable(() =>
            {
                PostStateChange.Remove(executor);

                executor.Dispose();
            });

            PropChangeDisposables.Add(disposable);

            Disposables.Add(disposable);

            return disposable;
        }

        protected sealed override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var executors = PostStateChange.ToList();

            PostStateChange.Clear();

            foreach (var executor in executors)
            {
                executor.Execute();
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var disposables = PropChangeDisposables.ToList();

            Dispose(PropChangeDisposables);

            await base.SetParametersAsync(parameters);

            foreach (var disposable in disposables)
            {
                Disposables.Remove(disposable);
            }
        }

        protected IDisposable AddDisposal(IDisposable disposable)
        {
            Disposables.Add(disposable);

            return disposable;
        }

        protected void Dispose(List<IDisposable> disposers)
        {
            var disposables = disposers.ToArray();

            disposers.Clear();

            foreach (var disposable in disposables)
            {
                disposable?.Dispose();
            }
        }

        protected IDisposable RunTimeout(Action action, int delay)
        {
            return AddDisposal(SetTimeout(action, delay));
        }

        protected IDisposable RunInterval(Action action, int interval)
        {
            return AddDisposal(SetInterval(action, interval));
        }

        public static IDisposable SetTimeout(Action action, int delay = 0)
        {
            if (delay <= 0)
            {
                action();

                return null;
            }

            return ExecutionPlan.Delay(delay, action);
        }

        public static IDisposable SetInterval(Action action, int interval)
        {
            return ExecutionPlan.Repeat(interval, action);
        }

        public static IExecutor CreateTimeout(Action action, int delay = 0)
        {
            return new Executor(() => SetTimeout(action, delay));
        }

        ValueTask IAsyncDisposable.DisposeAsync()
        {
            Mounted = false;

            OnAfterUnmount();

            Dispose(Disposables);

            Dispose();

            return DisposeAsync();
        }

        protected virtual void OnAfterUnmount()
        {
        }

        protected virtual ValueTask DisposeAsync()
        {
            return default;
        }
    }
}
