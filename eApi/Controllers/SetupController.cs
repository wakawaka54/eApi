using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using eApi.Domain.Integrations.eBay;

using eBay.Service.Core.Sdk;
using eBay.Service.Call;
using eBay.Service.Core.Soap;

namespace eApi.Controllers
{
    public class SetupController : Controller
    {
        ApiContext context;

        public SetupController(eBayApi api)
        {
            context = api.GetContext();
        }

        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveNotifications()
        {
            GetNotificationPreferencesCall call = new GetNotificationPreferencesCall(context);
            call.PreferenceLevel = eBay.Service.Core.Soap.NotificationRoleCodeType.User;
            call.Execute();

            return PartialView(call.UserDeliveryPreferenceList);
        }
    }
}