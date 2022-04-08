using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class TransactionResponse : ITransactionResponse
    {
        public TransactionResponse(TransactionResult result, string curr, Dictionary<string, decimal> dictionary1, Dictionary<string, decimal> dictionary2)
        {
            Currency = curr;
            Result = result;
            SourceBalances = dictionary1;
            DestBalances = dictionary2;
        }

        public TransactionResult Result
        {
            get;	
        }

        public string Currency { get; }

        public IDictionary<string, decimal> SourceBalances { get; }
        public IDictionary<string, decimal> DestBalances { get; }
    }
}
