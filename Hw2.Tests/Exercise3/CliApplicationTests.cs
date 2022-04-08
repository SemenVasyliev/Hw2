using System;
using Hw2.Exercise3;
using Hw2.Exercise3.Plugins;
using Xunit;
using static Hw2.Exercise3.CliApplication;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise3
{
    public partial class CliApplicationTests
    {

        [Fact]
        public void Creates_WithNullArgs_ThrowsNullArgException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                return new CliApplication(null);
            });
            Assert.Equal("plugins", ex.ParamName);
        }

        [Fact]
        public void Creates_WithInvalidArgs_ThrowsArgException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return new CliApplication(new ICliPlugin[]
                {
                    new CounterPlugin(),
                    null,
                    new TrialExceptionPlugin()
                });
            });
            Assert.Equal("plugins", ex.ParamName);
        }

        [Fact]
        public void Creates_WithEmptyArgs_ThrowsNothing()
        {
            _ = new CliApplication(Array.Empty<ICliPlugin>());
        }

        [Fact]
        public void Runs_WithNullArgs_ReturnsPluginNotFound()
        {
            var app = new CliApplication(Array.Empty<ICliPlugin>());
            var result = app.Run(null);
            Assert.Equal(ReturnCode.PluginNotFound, result);
        }

        [Fact]
        public void Runs_WithUnkownPlugin_ReturnsPluginNotFound()
        {
            var app = new CliApplication(new ICliPlugin[]
            {
                new CounterPlugin(),
            });
            var result = app.Run(new string[] { "some", "args" });
            Assert.Equal(ReturnCode.PluginNotFound, result);
        }

        [Fact]
        public void Runs_WithErrorPlugin_ReturnsPluginError()
        {
            var app = new CliApplication(new ICliPlugin[]
            {
                new CounterPlugin(),
                new TrialExceptionPlugin(),
            });
            var result = app.Run(new string[] { "some", "args" });
            Assert.Equal(ReturnCode.PluginError, result);
        }

        [Fact]
        public void Runs_WithValidPlugin_ReturnsSuccess()
        {
            var inc = new CounterPlugin(command: "inc");
            var dec = new CounterPlugin(command: "dec", counterStep: -1);
            var app = new CliApplication(new ICliPlugin[]
            {
                inc,
                dec
            });

            var result = app.Run(new string[] { "INC" });
            Assert.Equal(ReturnCode.Success, result);

            result = app.Run(new string[] { "DEC" });
            Assert.Equal(ReturnCode.Success, result);

            Assert.Equal(1, inc.Counter);
            Assert.Equal(-1, dec.Counter);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
