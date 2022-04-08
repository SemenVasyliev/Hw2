using System;
using Hw2.Exercise2;
using Xunit;

namespace Hw2.Tests.Exercise2
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public class ExchangeRequestTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("please")]
        [InlineData("exchange please")]
        [InlineData("exchange please 10 EUR")]
        [InlineData("-10 EUR USD")]
        [InlineData("10 EUR")]
        [InlineData("EUR 10 USD")]
        public void Parse_WithInvalidArgs_ReturnsInvalidRequest(string args)
        {
            var result = ExchangeRequest.TryParse(args?.Split(' ', StringSplitOptions.RemoveEmptyEntries), out var request);
            Assert.True(!result || !request.IsValid);
        }

        [Theory]
        [InlineData("10 USD EUR", 10, "USD", "EUR")]
        [InlineData("10 EUR USD", 10, "EUR", "USD")]
        [InlineData("10 eur usd", 10, "EUR", "USD")]
        [InlineData("1000.23 eur usd", 1000.23, "EUR", "USD")]
        [InlineData("1000,23 eur usd", 1000.23, "EUR", "USD")]
        public void Parse_WithValidArgs_ReturnsValidRequest(string args, decimal amount, string srcCurrency, string destCurrency)
        {
            var result = ExchangeRequest.TryParse(args?.Split(' ', StringSplitOptions.RemoveEmptyEntries), out var request);
            Assert.True(result && request.IsValid);
            Assert.Equal(amount, request.Amount);
            Assert.Equal(srcCurrency, request.SourceCurrnecy, StringComparer.OrdinalIgnoreCase);
            Assert.Equal(destCurrency, request.DestCurrency, StringComparer.OrdinalIgnoreCase);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
