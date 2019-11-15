using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public class DisposableComponent : RenderComponent, IDisposable
    {
        private List<IDisposable> Disposables { get; set; } = new List<IDisposable>();

        private List<IDisposable> PropChangeDisposables { get; set; } = new List<IDisposable>();

        private List<IExecutor> PostStateChange { get; set; } = new List<IExecutor>();

        protected IDisposable StateHasChanged(IExecutor executor)
        {
            PostStateChange.Add(executor);

            StateHasChanged();

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

            foreach(var executor in executors)
            {
                executor.Execute();
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var disposables = PropChangeDisposables.ToList();

            Dispose(PropChangeDisposables);

            await base.SetParametersAsync(parameters);

            foreach(var disposable in disposables)
            {
                Disposables.Remove(disposable);
            }
        }

        protected void AddDisposal(IDisposable disposable)
        {
            Disposables.Add(disposable);
        }

        protected virtual void Dispose()
        {
        }

        protected virtual void OnAfterUnmount()
        {
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

        void IDisposable.Dispose()
        {
            Mounted = false;

            OnAfterUnmount();

            Dispose(Disposables);

            Dispose();
        }

        protected void RunTimeout(Action action, int delay)
        {
            AddDisposal(SetTimeout(action, delay));
        }

        public static IDisposable SetTimeout(Action action, int delay = 0)
        {
            if(delay <= 0)
            {
                action();

                return null;
            }

            return ExecutionPlan.Delay(delay, action);
        }

        public static IExecutor CreateTimeout(Action action, int delay = 0)
        {
            return new Executor(() => SetTimeout(action, delay));
        }
    }
}
