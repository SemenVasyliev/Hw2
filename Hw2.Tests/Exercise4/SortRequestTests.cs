using System;
using Hw2.Exercise4;
using Xunit;

namespace Hw2.Tests.Exercise4
{
#pragma warning disable CA1707 // Identifiers should not contain underscores

    public class SortRequestTests
    {
        [Fact]
        public void Creates_WithNullSortAlg_ThrowsNullArgException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                return new SortRequest(null, Array.Empty<int>());
            });
            Assert.Equal("sortAlgorithm", ex.ParamName);
        }

        [Fact]
        public void Creates_WithNullArray_ThrowsNullArgException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                return new SortRequest("System", null);
            });
            Assert.Equal("array", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("sort please")]
        [InlineData("quick a 1 b 2 c 3")]
        [InlineData("quick 1.23 4,56")]
        public void Parse_WithInvalidArgs_ReturnsFalse(string args)
        {
            var result = SortRequest.TryParse(args?.Split(' ', StringSplitOptions.RemoveEmptyEntries), out var request);
            Assert.False(result);
        }

        [Fact]
        public void Parse_WithEmptyArray_ReturnsValidRequest()
        {
            var result = SortRequest.TryParse(new[] { "System" }, out var request);
            Assert.True(result);
            Assert.Equal("System", request.SortAlgorith, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(request.Array);
            Assert.Empty(request.Array);
        }

        [Theory]
        [InlineData("Bubble 1 0 3 4 5 2 -1", new int[] { 1, 0, 3, 4, 5, 2, -1 })]
        [InlineData("System 1 0 3 4 5 2 -1", new int[] { 1, 0, 3, 4, 5, 2, -1 })]
        [InlineData("Quick 1 0 3 4 5 2 -1", new int[] { 1, 0, 3, 4, 5, 2, -1 })]
        public void Parse_WithValidArgs_ReturnsValidRequest(string args, int[] expectedArray)
        {
            var parsed = SortRequest.TryParse(args.Split(' ', StringSplitOptions.RemoveEmptyEntries), out var request);
            Assert.True(parsed);
            Assert.Equal(expectedArray, request.Array);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
