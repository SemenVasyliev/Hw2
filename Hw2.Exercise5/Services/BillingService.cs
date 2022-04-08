using System.Reflection;
using Hw2.Exercise5.Models;

namespace Hw2.Exercise5.Services
{
    /// <summary>
    /// Billing system core.
    /// </summary>
    public class BillingService : IBillingService
    {
        Dictionary<string, decimal> dictionary1 = new Dictionary<string, decimal>();
        Dictionary<string, decimal> dictionary2 = new Dictionary<string, decimal>();
        Dictionary<string, Dictionary<string, Dictionary<string, decimal>>> Balances = new Dictionary<string, Dictionary<string,Dictionary<string, decimal>>>();
        /// <inheritdoc/>
        public ITransactionResponse ProcessTransaction(ITransactionRequest request)
        {
            if (request == null || request.TransactionId == "" || request.SourceBalance == "" || request.Amount.ToString() == ""
                || request.OverdraftAllowed == false || request.SourceUserId == "" || request.DestBalance == ""
                || request.DestUserId == "" || request.Timestamp.ToString() == "" || request.Currency == "")
            {
                return new TransactionResponse(TransactionResult.InvalidRequest, "", dictionary1, dictionary2);
            }
            if (true)
            {

            }
            return new TransactionResponse(TransactionResult.Success, request.Currency, dictionary1, dictionary2);
        }

        public IUserBalancesResponse? GetUserBalances(string userId)
        {
            if (Balances.TryGetValue(userId, out var balances))
            {
                return null;
            }
            else
            {
                return (IUserBalancesResponse?)balances;
            }
        }
    }
}
