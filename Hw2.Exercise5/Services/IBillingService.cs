using Hw2.Exercise5.Models;

namespace Hw2.Exercise5.Services
{
    /// <summary>
    /// Billing system core.
    /// </summary>
    public interface IBillingService
    {
        /// <summary>
        /// Processes billing transactions requests.
        /// </summary>
        /// <param name="request">Transaction request. Can be null.</param>
        /// <returns>
        /// Always returns instance of <see cref="ITransactionResponse"/> 
        /// (even for cases, when <paramref name="request"/> is missing or corrupted).
        /// </returns>
        ITransactionResponse ProcessTransaction(ITransactionRequest request);

        /// <summary>
        /// Tries to find user balances.
        /// </summary>
        /// <param name="userId">User id to find.</param>
        /// <returns>Returns user balances or <c>null</c> if nothing was found.</returns>
        IUserBalancesResponse? GetUserBalances(string userId);
    }
}
