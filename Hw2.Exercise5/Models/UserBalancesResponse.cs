using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class UserBalancesResponse : IUserBalancesResponse
    {
        public UserBalancesResponse(Dictionary<string, IDictionary<string, decimal>> balances)
        {
           Balances = balances;
        }

        public IDictionary<string, IDictionary<string, decimal>> Balances { get; set; }
    }
}
