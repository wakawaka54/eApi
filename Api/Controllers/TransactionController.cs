using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

using eApi.Domain;
using eApi.Models;

namespace Api.Controllers
{
    public class TransactionController : ApiController
    {
        [HttpPost]
        public async void Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();

            TransactionModel model = new TransactionModel();

            XDocument doc = XDocument.Load(stream);

            model.Quantity = int.Parse(doc.Descendants().FirstOrDefault(x => x.Name.LocalName.Contains("Quantity")).Value);
            model.ItemID = doc.Descendants().FirstOrDefault(x => x.Name.LocalName.Contains("ItemID")).Value;
            model.OrderID = doc.Descendants().FirstOrDefault(x => x.Name.LocalName.Contains("ExtendedOrderID")).Value;

            eDbContext db = new eDbContext();
            db.Transactions.Add(model);

            await db.SaveChangesAsync();
        }
    }
}
