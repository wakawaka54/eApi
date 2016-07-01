using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Threading.Tasks;

using eApi.Domain.Integrations.eBay;

using eBay.Service.Core.Sdk;
using eBay.Service.Call;
using eBay.Service.Core.Soap;

namespace eApi.Controllers
{
    public class SetupController : Controller
    {
        ApiContext context;
        GetNotificationPreferencesCall getNotificationPreferences;
        Task asyncRequest;

        public SetupController(eBayApi api)
        {
            context = api.GetContext();

            getNotificationPreferences = new GetNotificationPreferencesCall(context);
            getNotificationPreferences.PreferenceLevel = eBay.Service.Core.Soap.NotificationRoleCodeType.User;

            asyncRequest = new Task(getNotificationPreferences.Execute);
            asyncRequest.Start();
        }

        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveNotifications()
        {
            asyncRequest.Wait();
            return PartialView(getNotificationPreferences.UserDeliveryPreferenceList);
        }

        public ActionResult ApplicationSettings()
        {
            asyncRequest.Wait();
            return PartialView(getNotificationPreferences.ApplicationDeliveryPreferences);
        }
    }
}