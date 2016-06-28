using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eApi.Domain.Integrations.eBay;

using eBay.Service.Core.Sdk;
using eBay.Service.Call;

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
            GetNotificationPreferencesCall call = new GetNotificationPreferencesCall(context);
            call.PreferenceLevel = eBay.Service.Core.Soap.NotificationRoleCodeType.User;
            call.Execute();

            return View(call.UserDeliveryPreferenceList);
        }
    }
}