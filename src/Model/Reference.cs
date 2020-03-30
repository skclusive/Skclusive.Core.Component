using Microsoft.AspNetCore.Components;

namespace Skclusive.Core.Component
{
    public interface IReference
    {
        string Name { set; get; }

        ElementReference? Current { set; get; }
    }

    public class Reference : IReference
    {
        public string Name { set; get; }

        public Reference(string name = "Unamed")
        {
            Name = name;
        }

        public readonly static Reference Empty = new Reference("Empty");

        public virtual ElementReference? Current { set; get; }
    }

    public class DelegateReference : Reference
    {
        private IReference[] _references;

        public DelegateReference(params IReference[] references)
            : this("DelegateUnamedRef", references)
        {
        }

        public DelegateReference(string name, params IReference[] references)
            : base(name)
        {
            _references = references;
        }

        public override ElementReference? Current
        {
            get => base.Current;
            set
            {
                foreach (var reference in _references)
                {
                    reference.Current = value;
                }
                base.Current = value;
            }
        }
    }
}
