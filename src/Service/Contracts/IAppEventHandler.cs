using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skclusive.Core.Component
{
    public interface IAppEventHandler : IAsyncDisposable
    {
        Task OnInitializedAsync();

        Task OnMountedAsync();
    }
}
