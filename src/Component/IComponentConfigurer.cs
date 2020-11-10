using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Skclusive.Core.Component
{
    public interface IComponentConfigurer
    {
        (IDisposable, RenderFragment) Configure(RenderFragment renderFragment, Func<Task> renderer);
    }
}