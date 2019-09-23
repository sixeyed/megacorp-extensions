using Prometheus;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extensions for <see cref="IApplicationBuilder"/>
    /// </summary>
    /// <remarks>
    /// Use in ASP.NET Core startup to configure a standard pipeline
    /// </remarks>
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Add standard security headers to all HTTP responses
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <returns>Application builder</returns>
        public static IApplicationBuilder UseStandardHeaders(this IApplicationBuilder app)
        {
            app.UseSecurityHeaders();
            return app;
        }

        /// <summary>
        /// Add a /metrics endpoint publishing standard app metrics in Prometheus format
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <returns>Application builder</returns>
        public static IApplicationBuilder UseStandardMetrics(this IApplicationBuilder app)
        {
            app.UseMetricServer();

            app.UseHttpMetrics(options =>
            {
                options.RequestCount.Enabled = true;
                options.RequestDuration.Enabled = true;
            });

            return app;
        }

        /// <summary>
        /// Configure a standard ASP.NET Core pipeline, with security headers, metrics, error page and static files
        /// </summary>
        /// <remarks>
        /// This sets up the initial pipeline, then you need to configure your own routing components
        /// </remarks>
        /// <param name="app">Application builder</param>
        /// <param name="isDevelopment">If the app is running in the dev environment</param>
        /// <returns>Application builder</returns>
        public static IApplicationBuilder UseStandardPipeline(this IApplicationBuilder app, bool isDevelopment)
        {
            app.UseStandardMetrics();
            app.UseStandardHeaders();

            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            return app;
        }
    }
}