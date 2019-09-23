namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extensions to .NET Standard config framework
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds the standard config providers for configs and secrets
        /// </summary>
        /// <param name="config">Configuration builder</param>
        /// <returns>Configuration builder</returns>
        public static IConfigurationBuilder AddStandardProviders(this IConfigurationBuilder config)
        {
            return config.AddJsonFile("config/config.json", optional: true)
                         .AddJsonFile("config/secrets.json", optional: true);
        }
    }
}
