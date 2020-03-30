namespace Skclusive.Core.Component
{
    public interface IRenderContext
    {
        bool IsServer { get; }

        bool IsPreRendering { get; }
    }
}
