using System;
using System.Linq;
using Hw2.Exercise3.Plugins;

namespace Hw2.Tests.Exercise3
{
    internal class CounterPlugin : ICliPlugin
    {
        public int Counter { get; private set; }
        public string Command { get; }
        public bool IgnoreCommandCase { get; }
        public int CounterStep { get; }

        public CounterPlugin(string command = "inc", bool ignoreCommandCase = true, int counterStep = 1)
        {
            Command = command;
            IgnoreCommandCase = ignoreCommandCase;
            CounterStep = counterStep;
        }

        public bool Handle(string[] args)
        {
            if (!string.Equals(
                args?.FirstOrDefault(),
                Command,
                IgnoreCommandCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
            {
                return false;
            }
            Counter += CounterStep;
            return true;
        }
    }
}
