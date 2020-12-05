namespace Skclusive.Core.Component
{
    public interface ICoreConfig
    {
        Theme Theme { get; }

        bool IsServer { get; }

        bool IsPreRendering { get; }

        bool DisableBinding { get; }

        bool DisableConfigurer { get; }
    }

    public abstract class CoreConfigBuilder<B, C>
    where B : CoreConfigBuilder<B, C>
    where C : ICoreConfig
    {
        protected class CoreConfig : ICoreConfig
        {
            public bool IsServer { get; internal set; }

            public bool IsPreRendering { get; internal set; }

            public bool DisableBinding { get; internal set; }

            public bool DisableConfigurer { get; internal set; }

            public Theme Theme { get; internal set; }
        }

        protected CoreConfig _config;

        protected abstract B Builder();

        protected abstract C Config();

        protected CoreConfigBuilder(CoreConfig config)
        {
            _config = config;

            _config.Theme = Theme.Light;
        }

        public B WithIsServer(bool isServer)
        {
            _config.IsServer = isServer;

            return Builder();
        }

        public B WithIsPreRendering(bool isPreRendering)
        {
            _config.IsPreRendering = isPreRendering;

            return Builder();
        }

        public B WithDisableBinding(bool disableBinding)
        {
            _config.DisableBinding = disableBinding;

            return Builder();
        }

        public B WithDisableConfigurer(bool disableConfigurer)
        {
            _config.DisableConfigurer = disableConfigurer;

            return Builder();
        }


        public B WithTheme(Theme theme)
        {
            _config.Theme = theme;

            return Builder();
        }

        public B With(ICoreConfig config)
        {
            WithIsServer(config.IsServer);

            WithIsPreRendering(config.IsPreRendering);

            WithDisableBinding(config.DisableBinding);

            WithDisableConfigurer(config.DisableConfigurer);

            WithTheme(config.Theme);

            return Builder();
        }

        public C Build()
        {
            return Config();
        }
    }

    public class CoreConfigBuilder : CoreConfigBuilder<CoreConfigBuilder, ICoreConfig>
    {
        public CoreConfigBuilder() : base(new CoreConfig())
        {
        }

        protected override ICoreConfig Config()
        {
            return _config;
        }

        protected override CoreConfigBuilder Builder()
        {
            return this;
        }
    }
}
