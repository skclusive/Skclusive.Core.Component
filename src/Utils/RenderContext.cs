namespace Skclusive.Core.Component
{
    public class RenderContext : IRenderContext
    {
        public RenderContext(bool isServer = false, bool isPreRendering = true)
        {
            IsServer = isServer;
            IsPreRendering = isPreRendering;
        }

        public bool IsServer { get; private set; }

        public bool IsPreRendering { get; private set; }
    }
}
