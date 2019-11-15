using System;

namespace Skclusive.Core.Component
{
    public interface IExecutor : IDisposable 
    {
        void Execute();
    }
}
