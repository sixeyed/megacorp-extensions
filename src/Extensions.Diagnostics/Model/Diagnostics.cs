namespace Extensions.Diagnostics.Model
{
    /// <summary>
    /// .NET system diagnostics
    /// </summary>
    public class Diagnostics
    {
        /// <summary>
        /// System architecture of the current runtime
        /// </summary>
        public string OSArchitecture { get; set; }

        /// <summary>
        /// Operating system of the current runtime
        /// </summary>
        public string OSDescription { get; set; }

        /// <summary>
        /// Machine name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// .NET framework version
        /// </summary>
        public string FrameworkDescription { get; set; }
    }
}
