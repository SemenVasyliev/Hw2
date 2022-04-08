namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency rates application core.
    /// </summary>
    public sealed class CurrencyRatesApplication
    {
        /// <summary>
        /// Currency rates application return codes.
        /// </summary>
        public enum ReturnCode
        {
            Success = 0,
            InvalidArgs = -1,
            UnknownCurrency = -2
        }

        private Dictionary<string, decimal> BootstrapRates => new()
        {
            ["USD"] = 1m,
            ["EUR"] = 1.2m
        };

        /// <summary>
        /// Runs currency rates application.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>
        /// Returns <see cref="ReturnCode.Success"/> in case of valid currency exchange.
        /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of invalid <paramref name="args"/>.
        /// Returns <see cref="ReturnCode.UnknownCurrency"/> in case of unknown currency from <paramref name="args"/>.
        /// </returns>
        public ReturnCode Run(string[] args)
        {
            var rates = new CurrencyRates(BootstrapRates);

            if (!ExchangeRequest.TryParse(args, out var request) || !request.IsValid)
                return ReturnCode.InvalidArgs;

            var exchangeResult = rates.Exchange(request);

            if (!exchangeResult.HasValue)
                return ReturnCode.UnknownCurrency;

            Console.WriteLine(
                "{0:G4} {1} = {2:G4} {3}",
                request.Amount,
                request.SourceCurrnecy,
                exchangeResult,
                request.DestCurrency);

            return ReturnCode.Success;
        }
    }
}
