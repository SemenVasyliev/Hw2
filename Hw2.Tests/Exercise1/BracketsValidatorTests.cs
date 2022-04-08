using System;
using Hw2.Exercise1;
using Xunit;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise1
{
    public class BracketsValidatorTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("abc", true)]
        [InlineData("a|b c|d", true)]
        [InlineData("a|b*12345678*c|d", true)]

        public void Validate_WithoutBrackets_ReturnsValid(string sequence, bool isValid)
        {
            var validator = new BracketsValidator();
            var result = validator.IsSequenceValid(sequence);
            Assert.Equal(isValid, result);
        }

        [Theory]
        [InlineData("{this is <c>true</c> code block}")]
        [InlineData("(array definition : char[] arr = new ['a', '{', 'b', '}'];)")]
        [InlineData("(a)[[bc]{d}<ef>](g)")]
        [InlineData("<a|b<>c<|>d<>>")]
        [InlineData("<[{(()()[][]<><>{}{})}]>")]
        [InlineData("0<[{((1)(2)[3][4]<5><6>{7}{8})}]>*9*")]
        public void Validate_ValidSequence_ReturnsValid(string sequence)
        {
            var validator = new BracketsValidator();
            var isValid = validator.IsSequenceValid(sequence);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("a(bcd")]
        [InlineData("a<bcd")]
        [InlineData("a[bcd")]
        [InlineData("a{bcd")]
        [InlineData("a()bc)d")]
        [InlineData("a<>bc>d")]
        [InlineData("a[]bc]d")]
        [InlineData("a{}bc}d")]
        [InlineData("{this is <c>true</c] code block}")]
        [InlineData("(array definition : char[] arr = new ['a';)")]
        [InlineData("(a)[<bc]{d}<ef>](g)")]
        [InlineData("<a|b<<c<|>d<>>")]
        [InlineData("<[{(()()[][]<|<>{}{})}]>")]
        [InlineData("[{(()()[][]<><>{}{})}]>")]
        [InlineData("<[{(()()[][]<><>{}{})}]")]
        [InlineData("0<[{((1)(2)[3][4]<5><6>{7}{8})}]*")]
        public void Validate_InvalidSequence_ReturnsInvalid(string sequence)
        {
            var validator = new BracketsValidator();
            var isValid = validator.IsSequenceValid(sequence);
            Assert.False(isValid);
        }

        [Fact]
        public void Validate_NullSequence_ThrowsArgException()
        {
            _ = Assert.ThrowsAny<ArgumentNullException>(() =>
              {
                  var validator = new BracketsValidator();
                  _ = validator.IsSequenceValid(null);
              });
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
