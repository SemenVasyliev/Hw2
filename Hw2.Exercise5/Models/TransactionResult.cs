namespace Hw2.Exercise5.Models
{
    /// <summary>
    /// Transaction processing result.
    /// </summary>
    public enum TransactionResult
    {
        /// <summary>
        /// Transaction was processed without errors.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Unexpected error.
        /// </summary>
        Fail = 1,

        /// <summary>
        /// Insufficient funds to process transaction.
        /// </summary>
        InsufficientFunds = 2,

        /// <summary>
        /// Invalid transaction request.
        /// </summary>
        InvalidRequest = 3
    }
}
