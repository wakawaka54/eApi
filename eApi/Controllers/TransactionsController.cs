using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eApi.Domain;

namespace eApi.Controllers
{
    public class TransactionsController : Controller
    {
        ITransactionRepository repository;

        public TransactionsController(ITransactionRepository r)
        {
            repository = r;
        }

        // GET: Transactions
        public ActionResult Index()
        {
            
            return View(repository.Transactions);
        }
    }
}