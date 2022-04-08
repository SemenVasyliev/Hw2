namespace Hw2.Exercise5.Models
{
    /// <summary>
    /// Billing transaction response. 
    /// </summary>
    public interface ITransactionResponse
    {
        /// <summary>
        /// Transaction result.
        /// </summary>
        public TransactionResult Result { get; }

        /// <summary>
        ///  Request currecny
        /// </summary>
        string Currency { get; }

        /// <summary>
        /// Source user balances in <see cref="Currency"/>.
        /// </summary>
        IDictionary<string, decimal> SourceBalances { get; }

        /// <summary>
        /// Destination user balances in <see cref="Currency"/>.
        /// </summary>
        IDictionary<string, decimal> DestBalances { get; }
    }
}
