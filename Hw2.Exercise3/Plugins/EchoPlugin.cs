namespace Hw2.Exercise3.Plugins
{
    /// <summary>
    /// Echo CLI plugin.
    /// </summary>
    internal class EchoPlugin : ICliPlugin
    {
        public const string EchoCommand = "echo";

        /// <inheritdoc/>
        public bool Handle(string[] args)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(args?.FirstOrDefault(), EchoCommand))
            {
                Console.Write(string.Join(' ', args[1..]));
                return true;
            }
            return false;
        }
    }
}
