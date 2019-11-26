using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public interface IReference
    {
        ElementReference? Current { set; get; }
    }

    public class Reference : IReference
    {
        public readonly static Reference Empty = new Reference();

        public virtual ElementReference? Current { set; get; }
    }

    public class DelegateReference : Reference
    {
        private IReference[] _references;

        public DelegateReference(params IReference[] references)
        {
            _references = references;
        }

        public override ElementReference? Current
        {
            get => base.Current;
            set
            {
                foreach (var reference in _references)
                    reference.Current = value;
                base.Current = value;
            }
        }
    }
}
