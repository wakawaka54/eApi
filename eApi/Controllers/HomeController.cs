using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eApi.Domain;
using eApi.Models;

using eApi.Domain.Integrations.eBay;

using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;

namespace eApi.Controllers
{
    public class HomeController : Controller
    {
        ITransactionRepository transactions;
        ApiContext ebayContext;

        public HomeController(ITransactionRepository t, eBayApi context)
        {
            transactions = t;
            ebayContext = context.GetContext();
        }

        // GET: Home
        public ActionResult Index()
        { 
            GetNotificationPreferencesCall call1 = new GetNotificationPreferencesCall(ebayContext);
            call1.PreferenceLevel = NotificationRoleCodeType.Application;

            call1.Execute();

            SetNotificationPreferencesCall call = new SetNotificationPreferencesCall(ebayContext);
            call.ApplicationDeliveryPreferences = new ApplicationDeliveryPreferencesType()
            {
                ApplicationURL = "http://localhost:55479/api/transaction",
                ApplicationEnable = EnableCodeType.Disable,
                DeviceType = DeviceTypeCodeType.Platform,
                AlertEnable = EnableCodeType.Enable,
                AlertEmail = "mailto://abello.2015@gmail.com"
            };

            call.UserDeliveryPreferenceList = new NotificationEnableTypeCollection();
            call.UserDeliveryPreferenceList.Add(new NotificationEnableType()
            {
                EventType = NotificationEventTypeCodeType.FixedPriceTransaction,
                EventEnable = EnableCodeType.Enable
            });

            call.Execute();

            return View();
        }
    }
}