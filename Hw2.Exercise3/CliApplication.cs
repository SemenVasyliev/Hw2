using Hw2.Exercise3.Plugins;

namespace Hw2.Exercise3
{
    /// <summary>
    /// CLI plugin application.
    /// </summary>
    public sealed class CliApplication
    {
        public IEnumerable<ICliPlugin> Plugins { get; }

        /// <summary>
        /// CLI application return codes.
        /// </summary>
        public enum ReturnCode
        {
            Success = 0,
            PluginNotFound = -1,
            PluginError = -2
        }

        /// <summary>
        /// Creates instance of <see cref="CliApplication"/>.
        /// </summary>
        /// <param name="plugins">Plugins collection.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="plugins"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when <paramref name="plugins"/> contains nulls.
        /// </exception>
        public CliApplication(IEnumerable<ICliPlugin> plugins)
        {
            if (plugins == null)
            {
                throw new ArgumentNullException(nameof(plugins));
            }
            foreach (var p in plugins)
            {
                if (p == null)
                {
                    throw new ArgumentException("ex", nameof(plugins));
                }
            }
            Plugins = plugins;
        }

        /// <summary>
        /// Runs CLI plugins application.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <returns>
        /// Returns <see cref="ReturnCode.Success"/> in case of success.
        /// Returns <see cref="ReturnCode.PluginNotFound"/> in case when no one plugin has accepted CLI arguments.
        /// Returns <see cref="ReturnCode.PluginError"/> in case of plugin internal error during CLI arguments processing.
        /// </returns>
        public ReturnCode Run(string[] args)
        {         
            try
            {
                foreach (var plugins in Plugins)
                {
                    if (plugins.Handle(args))
                    {
                        return ReturnCode.Success;
                    }
                }
                return ReturnCode.PluginNotFound;
            }
            catch
            {
                return ReturnCode.PluginError;
            }
        }
    }
}
