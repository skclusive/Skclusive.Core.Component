using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public class Reference
    {
        public readonly static Reference Empty = new Reference();

        public ElementReference? Current { set; get; }
    }
}
