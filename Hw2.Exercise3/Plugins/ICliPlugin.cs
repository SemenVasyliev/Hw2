namespace Hw2.Exercise3.Plugins
{
    /// <summary>
    /// Command-line interface plug-in.
    /// </summary>
    public interface ICliPlugin
    {
        /// <summary>
        /// Handles CLI arguments.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="args"/> can be handled by plugin.
        /// Otherwise returns <c>false</c>.
        /// </returns>
        bool Handle(string[] args);
    }
}
