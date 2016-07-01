using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace eApi.Models
{
    public class TransactionModel
    {
        //public DateTime Timestamp { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Key]
        public string ItemID { get; set; }
        public string OrderID { get; set; }
        public int Quantity { get; set; }
    }
}