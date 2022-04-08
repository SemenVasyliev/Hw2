namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency exchange service.
    /// </summary>
    public class CurrencyRates
    {
        Dictionary<string, decimal> myRates = new();
        public CurrencyRates(IDictionary<string, decimal> rates)
        {
            if (rates == null)
            {
                  throw new ArgumentNullException(nameof(rates));
            }
            if (rates.ElementAt(0).Key.ToLower() == rates.ElementAt(1).Key.ToLower()
                || rates.ElementAt(0).Value <= 0 || rates.ElementAt(1).Value <= 0)
            {
                throw new ArgumentException("rates", nameof(rates));
            }          
            for (int i = 0; i < rates.Count; i++)
            {
                var item = rates.ElementAt(i);
                myRates.Add(item.Key.ToLower(), item.Value);
            }

        }

        /// <summary>
        /// Exchanges currencies.
        /// </summary>
        /// <param name="request">Currency exchange request.</param>
        /// <returns>
        /// Returns amount of desired currency or <c>null</c> if requested currency is unknown.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="ExchangeRequest.IsValid"/> indicates invalid request.
        /// </exception>
        public decimal? Exchange(ExchangeRequest request)
        {
            if (!request.IsValid)
            {
                throw new ArgumentException("request", nameof(request));
            }    
            decimal result;
            switch (request.SourceCurrnecy.ToLower())
            {
                case "eur":
                    result = request.Amount * myRates["eur"];
                    return result;
                case "usd":
                    result = request.Amount * myRates["usd"];
                    return result;
                default: return null;
            }
        }
    }
}
