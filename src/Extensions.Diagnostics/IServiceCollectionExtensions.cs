using Extensions.Diagnostics.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to ASP.NET Core services
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add standard diagnostics service 
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddDiagnostics(this IServiceCollection services)
        {
            return services.AddSingleton<DiagnosticsService>();
        }
    }
}