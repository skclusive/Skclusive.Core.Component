namespace Skclusive.Core.Component
{
    public interface IComponentContext
    {
        bool? Disabled { get; }

        string Class { get; }

        string Style { get; }

        IReference RefBack { get; }
    }

    public abstract class ComponentContextBuilder<B, C>
        where B : ComponentContextBuilder<B, C>
        where C : IComponentContext
    {
        public class ComponentContext : IComponentContext
        {
            public bool? Disabled { get; internal set; }

            public string Class { get; internal set; }

            public string Style { get; internal set; }

            public IReference RefBack { get; internal set; }
        }

        protected virtual ComponentContext Context { get; }

        protected ComponentContextBuilder(ComponentContext context)
        {
            Context = context;
        }

        public virtual C Build()
        {
            // TODO: possible runtime exception. need to find a way
            return (C)(object)Context;
        }

        public B WithDisabled(bool? disabled)
        {
            Context.Disabled = disabled;

            return This();
        }

        public B WithClass(string clazz)
        {
            Context.Class = clazz;

            return This();
        }

        public B WithStyle(string style)
        {
            Context.Style = style;

            return This();
        }

        public B WithRefBack(IReference refBack)
        {
            Context.RefBack = refBack;

            return This();
        }

        public B With(IComponentContext context)
        {
            WithDisabled(context.Disabled);
            WithClass(context.Class);
            WithStyle(context.Style);
            WithRefBack(context.RefBack);

            return This();
        }

        public virtual B With(C context)
        {
            With((IComponentContext)context);

            return This();
        }

        protected abstract B This();
    }

    public class ComponentContextBuilder : ComponentContextBuilder<ComponentContextBuilder, IComponentContext>
    {
        public ComponentContextBuilder() : base(new ComponentContext())
        {
        }

        protected override ComponentContextBuilder This()
        {
            return this;
        }
    }
}