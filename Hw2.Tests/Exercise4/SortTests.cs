using System;
using System.Collections.Generic;
using Hw2.Exercise4;
using Hw2.Exercise4.Sorting;
using Xunit;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise4
{
    public class SortTests
    {

        [Fact]
        public void Resolve_WithNullAlg_ReturnsNull()
        {
            var factory = new SortFactory();
            var sort = factory.ResolveSort(null);
            Assert.Null(sort);
        }

        [Fact]
        public void Resolve_WithUnkownAlg_ReturnsNull()
        {
            var factory = new SortFactory();
            var sort = factory.ResolveSort("SOMEUNKNOWNALG");
            Assert.Null(sort);
        }

        [Fact]
        public void Sort_WithNullArray_ThrowsNullArgException()
        {
            var factory = new SortFactory();
            var sort = factory.ResolveSort("System");
            var ex = Assert.Throws<ArgumentNullException>(() =>
              {
                  sort.Sort(null);
              });
            Assert.Equal("array", ex.ParamName);
        }

        [Theory]
        [InlineData("Bubble", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("System", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("Quick", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("buBBle", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("SySTeM", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("QuicK", new[] { 2, 1 }, new[] { 1, 2 })]
        [InlineData("Bubble", new[] { 2, 1, -1, 2 }, new[] { -1, 1, 2, 2 })]
        [InlineData("System", new[] { 2, 1, -1, 2 }, new[] { -1, 1, 2, 2 })]
        [InlineData("Quick", new[] { 2, 1, -1, 2 }, new[] { -1, 1, 2, 2 })]
        public void Sort_Array_ReturnsRightOrder(string algorithm, int[] array, int[] expectedArray)
        {
            var factory = new SortFactory();
            var sort = factory.ResolveSort(algorithm);
            Assert.NotNull(sort);
            sort.Sort(array);
            Assert.Equal(expectedArray, array);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
