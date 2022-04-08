using System;
using Hw2.Exercise4;
using Xunit;
using static Hw2.Exercise4.SortApplication;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise4
{
    public class SortApplicationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("sort please")]
        [InlineData("quick a 1 b 2 c 3")]
        [InlineData("quick 1.23 4,56")]
        public void Runs_WithInvalidArgs_ReturnsInvalidArgs(string args)
        {
            var app = new SortApplication();
            var result = app.Run(args.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Equal(ReturnCode.InvalidArgs, result);
        }

        [Fact]
        public void Runs_WithNullArgs_ReturnsInvalidArgs()
        {
            var app = new SortApplication();
            var result = app.Run(null);
            Assert.Equal(ReturnCode.InvalidArgs, result);
        }

        [Fact]
        public void Runs_WithUnknownAlg_ReturnsUnknownSort()
        {
            // "Bubble", "System", "Quick"
            var app = new SortApplication();
            var result = app.Run(new[] { "SOMEUNKNOWNALG", "1", "2", "3" });
            Assert.Equal(ReturnCode.UnknownSort, result);
        }

        [Fact]
        public void Runs_WithValidSort_ReturnsResult()
        {
            var app = new SortApplication();
            var result = app.Run(new[] { "System", "1", "2", "3" });
            Assert.Equal(ReturnCode.Success, result);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
