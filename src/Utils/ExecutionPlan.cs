using System;
using System.Threading;
using Timer = System.Timers.Timer;

namespace Skclusive.Core.Component
{
    public class ExecutionPlan : IDisposable
    {
        private Timer planTimer;

        private readonly Action planAction;

        private readonly bool isRepeatedPlan;

        private SynchronizationContext context;

        private ExecutionPlan(int millisecondsDelay, Action planAction, bool isRepeatedPlan)
        {
            context = SynchronizationContext.Current;

            planTimer = new Timer(millisecondsDelay);

            planTimer.Elapsed += GenericTimerCallback;

            planTimer.Enabled = true;

            this.planAction = planAction;

            this.isRepeatedPlan = isRepeatedPlan;
        }

        public static ExecutionPlan Delay(int millisecondsDelay, Action planAction)
        {
            return new ExecutionPlan(millisecondsDelay, planAction, false);
        }

        public static ExecutionPlan Repeat(int millisecondsInterval, Action planAction)
        {
            return new ExecutionPlan(millisecondsInterval, planAction, true);
        }
        private void GenericTimerCallback(object sender, System.Timers.ElapsedEventArgs e)
        {
            context.Post(delegate
            {
                planAction();
            }, null);

            if (!isRepeatedPlan)
            {
                Abort();
            }
        }

        public void Abort()
        {
            planTimer.Enabled = false;
            planTimer.Elapsed -= GenericTimerCallback;
        }

        public void Dispose()
        {
            if (planTimer != null)
            {
                Abort();
                planTimer.Dispose();
                planTimer = null;
                context = null;
            }
            else
            {
                throw new ObjectDisposedException(typeof(ExecutionPlan).Name);
            }
        }
    }
}
