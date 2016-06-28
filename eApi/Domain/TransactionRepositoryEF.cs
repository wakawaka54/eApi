using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eApi.Models;

namespace eApi.Domain
{
    public class TransactionRepositoryEF : ITransactionRepository
    {
        eDbContext db = new eDbContext();

        public IEnumerable<TransactionModel> Transactions
        {
            get
            {
                return db.Transactions;
            }
        }
    }
}