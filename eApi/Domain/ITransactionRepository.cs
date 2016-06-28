using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eApi.Models;

namespace eApi.Domain
{
    public interface ITransactionRepository
    {
        IEnumerable<TransactionModel> Transactions { get; }
    }
}
