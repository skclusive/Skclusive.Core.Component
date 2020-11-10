using System;

namespace Skclusive.Core.Component
{
    public class EmptyDisposable : IDisposable
    {
        public static readonly IDisposable Empty = new EmptyDisposable();

        private EmptyDisposable()
        {
        }

        public void Dispose()
        {
        }
    }
}