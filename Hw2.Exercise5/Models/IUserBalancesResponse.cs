namespace Hw2.Exercise5.Models
{
    /// <summary>
    /// User balances response.
    /// </summary>
    public interface IUserBalancesResponse
    {
        /// <summary>
        /// User balances. 
        /// Non nullable.
        /// </summary>
        IDictionary<string, IDictionary<string, decimal>> Balances { get; }
    }
}
