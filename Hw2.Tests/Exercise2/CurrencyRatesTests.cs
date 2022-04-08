using System;
using System.Collections.Generic;
using Hw2.Exercise2;
using Xunit;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Hw2.Tests.Exercise2
{
    public class CurrencyRatesTests
    {
        private Dictionary<string, decimal> Rates => new()
        {
            ["USD"] = 1m,
            ["EUR"] = 1.2m
        };

        public static IEnumerable<object[]> GetInvalidRates()
        {
            var invalidRequests = new List<object[]>
            {
                new object[] { new Dictionary<string, decimal>()
                {
                    ["USD"] = 1m,
                    ["usd"] = 2m
                }},
                new object[] { new Dictionary<string, decimal>()
                {
                    ["USD"] = 1m,
                    ["EUR"] = -2m
                }},
                new object[] { new Dictionary<string, decimal>()
                {
                    ["USD"] = 1m,
                    ["EUR"] = 0m
                }},
            };
            return invalidRequests;
        }

        [Theory]
        [MemberData(nameof(GetInvalidRates))]
        public void Creates_WithInvalidRates_ThrowsArgException(IDictionary<string, decimal> rates)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return new CurrencyRates(rates);
            });
            Assert.Equal("rates", ex.ParamName);
        }

        [Fact]
        public void Creates_WithNullRates_ThrowsNullArgException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
              {
                  return new CurrencyRates(null);
              });
            Assert.Equal("rates", ex.ParamName);
        }

        [Fact]
        public void Exchange_WithInvalidRequest_ThrowsArgException()
        {
            var rates = new CurrencyRates(Rates);
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return rates.Exchange(new ExchangeRequest(-10, null, null));
            });
            Assert.Equal("request", ex.ParamName);
        }

        [Fact]
        public void Exchange_WithUnkownCurrency_ReturnsEmptyResult()
        {
            var rates = new CurrencyRates(Rates);
            var result = rates.Exchange(new ExchangeRequest(10, "SOMECURRENCY", "USD"));
            Assert.Null(result);
        }

        [Theory]
        [InlineData(10, "EUR", "USD", 12)]
        [InlineData(10.1, "EUR", "USD", 12.12)]
        public void Exchange_WithValidRequestAndRates_ReturnsValidResult(
            decimal amount, string srcCurrency, string destCurrency, decimal expectedResult)
        {
            var rates = new CurrencyRates(Rates);
            var result = rates.Exchange(new ExchangeRequest(amount, srcCurrency, destCurrency));
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, "EUR", "USD", 12)]
        [InlineData(10.1, "EUR", "USD", 12.12)]
        public void Exchange_WithValidRequestAndResetRates_ReturnsValidResult(
            decimal amount, string srcCurrency, string destCurrency, decimal expectedResult)
        {
            var ctxRates = Rates;
            var rates = new CurrencyRates(ctxRates);
            ctxRates.Clear();
            var result = rates.Exchange(new ExchangeRequest(amount, srcCurrency, destCurrency));
            Assert.Equal(expectedResult, result);
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
