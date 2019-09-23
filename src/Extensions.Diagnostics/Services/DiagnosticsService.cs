using System.Net;
using System.Runtime.InteropServices;
using Extensions.Diagnostics.Model;

namespace Extensions.Diagnostics.Services
{
    /// <summary>
    /// Service to fetch current runtime <see cref="Diagnostics"/>
    /// </summary>
    public class DiagnosticsService
    {
        private static readonly Model.Diagnostics _Diagnostics;

        static DiagnosticsService()
        {
            _Diagnostics = new Model.Diagnostics
            {
                OSArchitecture = RuntimeInformation.OSArchitecture.ToString(),
                OSDescription = RuntimeInformation.OSDescription,
                FrameworkDescription = RuntimeInformation.FrameworkDescription,
                HostName = Dns.GetHostName()
            };
        }

        /// <summary>
        /// Gets current runtime <see cref="Diagnostics"/>
        /// </summary>
        /// <returns>Current runtime status</returns>
        public Model.Diagnostics GetDiagnostics()
        {
            return _Diagnostics;
        }
    }
}
