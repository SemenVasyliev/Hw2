namespace Hw2.Exercise5.Models
{
    /// <summary>
    /// Billing transaction request. 
    /// </summary>
    public interface ITransactionRequest
    {
        /// <summary>
        /// Transaction unique identity.
        /// </summary>
        string TransactionId { get; }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// Transaction currency.
        /// </summary>
        string Currency { get; }

        /// <summary>
        /// Source user.
        /// </summary>
        string SourceUserId { get; }

        /// <summary>
        /// Destination user.
        /// </summary>
        string DestUserId { get; }

        /// <summary>
        /// Source balance.
        /// </summary>
        string SourceBalance { get; }

        /// <summary>
        /// Destination balance.
        /// </summary>
        string DestBalance { get; }

        /// <summary>
        /// Indicates that <see cref="SourceBalance"/> can be negative after transaction processing.
        /// </summary>
        bool OverdraftAllowed { get; }

        /// <summary>
        /// Transaction timestamp.
        /// </summary>
        DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Optional transaction metadata.
        /// </summary>
        string Metadata { get; }
    }
}
