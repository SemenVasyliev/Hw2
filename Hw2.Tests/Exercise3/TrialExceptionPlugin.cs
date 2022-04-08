using System;
using Hw2.Exercise3.Plugins;

namespace Hw2.Tests.Exercise3
{
    internal class TrialExceptionPlugin : ICliPlugin
    {
        public bool Handle(string[] args)
        {
            throw new InvalidOperationException("Trial period has ended");
        }
    }
}
