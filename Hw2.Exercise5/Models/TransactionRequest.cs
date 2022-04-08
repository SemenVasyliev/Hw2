using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class TransactionRequest : ITransactionRequest
    {
        public TransactionRequest(string transactionId, decimal amount, string currency, string sourceUserId, string destUserId, string sourceBalance, string destBalance, bool overdraftAllowed, DateTimeOffset timestamp, string metadata)
        {
            TransactionId = transactionId ?? throw new ArgumentNullException(nameof(transactionId));
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            SourceUserId = sourceUserId ?? throw new ArgumentNullException(nameof(sourceUserId));
            DestUserId = destUserId ?? throw new ArgumentNullException(nameof(destUserId));
            SourceBalance = sourceBalance ?? throw new ArgumentNullException(nameof(sourceBalance));
            DestBalance = destBalance ?? throw new ArgumentNullException(nameof(destBalance));
            OverdraftAllowed = overdraftAllowed;
            Timestamp = timestamp;
            Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        }

        public string TransactionId { get; }
                
        public decimal Amount { get; }

        public string Currency { get; }

        public string SourceUserId { get; }

        public string DestUserId { get; }

        public string SourceBalance { get; }

        public string DestBalance { get; }

        public bool OverdraftAllowed { get; }

        public DateTimeOffset Timestamp { get; }

        public string Metadata { get; }

    }
}
