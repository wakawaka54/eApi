using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.SqlServer;

using eApi.Models;

namespace eApi.Domain
{
    public class eDbContext : DbContext
    {
        public DbSet<TransactionModel> Transactions { get; set; }

        public eDbContext()
            :base("name=eApiDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}