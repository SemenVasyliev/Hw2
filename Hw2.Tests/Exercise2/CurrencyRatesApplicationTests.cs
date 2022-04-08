using System;
using Hw2.Exercise2;
using Xunit;
using static Hw2.Exercise2.CurrencyRatesApplication;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise2
{
    public class CurrencyRatesApplicationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("please")]
        [InlineData("exchange please")]
        [InlineData("exchange please 10 EUR")]
        [InlineData("-10 EUR USD")]
        [InlineData("10 EUR")]
        [InlineData("EUR 10 USD")]

        public void Runs_WithInvalidArgs_ReturnsInvalidArgs(string args)
        {
            var app = new CurrencyRatesApplication();
            var result = app.Run(args.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Equal(ReturnCode.InvalidArgs, result);
        }

        [Fact]
        public void Runs_WithNullArgs_ReturnsInvalidArgs()
        {
            var app = new CurrencyRatesApplication();
            var result = app.Run(null);
            Assert.Equal(ReturnCode.InvalidArgs, result);
        }

        [Fact]
        public void Runs_WithUnknownCurrecyArgs_ReturnsUnknownCurrency()
        {
            var app = new CurrencyRatesApplication();
            var result = app.Run(new[] { "10", "SOMEUNKNOWNCURRECNY", "USD" });
            Assert.Equal(ReturnCode.UnknownCurrency, result);
        }

        [Fact]
        public void Runs_WithValidRates_ReturnsResult()
        {
            var app = new CurrencyRatesApplication();
            var result = app.Run(new[] { "10", "EUR", "USD" });
            Assert.Equal(ReturnCode.Success, result);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
