using System;
using Hw2.Exercise1;
using Xunit;
using static Hw2.Exercise1.BracketsApplication;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise1
{
    public class BracketsApplicationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("a b c")]
        public void Run_WithoutBracketsArgs_ReturnsValid(string sequence)
        {
            var app = new BracketsApplication();
            var result = app.Run(sequence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Equal(ReturnCode.ValidSequence, result);
        }

        [Theory]
        [InlineData("<a>")]
        [InlineData("() abc {}")]
        [InlineData("a<[ {b( c) } ]>")]
        public void Run_WithValidArgs_ReturnsValid(string sequence)
        {
            var app = new BracketsApplication();
            var result = app.Run(sequence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Equal(ReturnCode.ValidSequence, result);
        }

        [Theory]
        [InlineData("<a}>")]
        [InlineData("( abc}")]
        [InlineData("a<[{b(c)}] (>)")]
        public void Run_WithInvalidValidArgs_ReturnsInvalid(string sequence)
        {
            var app = new BracketsApplication();
            var result = app.Run(sequence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Equal(ReturnCode.InvalidSequence, result);
        }

        [Fact]
        public void Run_WithNullSequence_ReturnsInvalidArgs()
        {
            var app = new BracketsApplication();
            var result = app.Run(null);
            Assert.Equal(ReturnCode.InvalidArgs, result);
        }

    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
