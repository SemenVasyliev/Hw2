using System.Globalization;

namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency exchange request.
    /// </summary>
    public readonly struct ExchangeRequest
    {
        /// <summary> Source amount.</summary>
        public decimal Amount { get; }

        /// <summary> Source currency.</summary>
        public string SourceCurrnecy { get; }

        /// <summary> Destination currency.</summary>
        public string DestCurrency { get; }

        /// <summary>
        /// Indicates if current request is valid.
        /// </summary>
        public bool IsValid =>
            Amount > decimal.Zero
            && SourceCurrnecy is not null
            && DestCurrency is not null;

        /// <summary>
        /// Creates new instance of <see cref="ExchangeRequest"/>.
        /// </summary>
        public ExchangeRequest(decimal amount, string sourceCurrnecy, string destCurrnecy)
        {
            Amount = amount;
            SourceCurrnecy = sourceCurrnecy;
            DestCurrency = destCurrnecy;
        }

        /// <summary>
        /// Tries to parse command line arguments as <see cref="ExchangeRequest"/>.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="request">Parsed request.</param>
        /// <returns>
        /// Returns <c>true</c> in case of success, otherwise returns <c>false</c>.
        /// </returns>
        public static bool TryParse(string[] args, out ExchangeRequest request)
        {  
            request = default;
            if (args == null || args.Length == 0)
            {
                return false;
            }           
            args[0] = args[0].Replace(',', '.');
            if (args.Length == 3 && decimal.TryParse(args[0], NumberStyles.Number, CultureInfo.InvariantCulture, out _))
            {
                decimal temp;
                decimal.TryParse(args[0], NumberStyles.Number, CultureInfo.InvariantCulture, out temp);
                request = new ExchangeRequest(temp, args[1], args[2]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
