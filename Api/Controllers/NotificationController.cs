using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Net.Security;

using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

using eApi.Domain.Integrations.eBay;

namespace Api.Controllers
{
    public class NotificationController : ApiController
    {
        ApiContext context;

        public NotificationController(eBayApi api)
        {
            context = api.GetContext();
        }

        [HttpPost]
        public IHttpActionResult Post(FormDataCollection data)
        {
            try
            {
                string notificationEvent = data.Get("notificationEvent");
                string notificationEnable = data.Get("notificationEnable");

                SetNotificationPreferencesCall call = new SetNotificationPreferencesCall(context);
                call.UserDeliveryPreferenceList = new NotificationEnableTypeCollection();
                call.UserDeliveryPreferenceList.Add(new NotificationEnableType()
                {
                    EventType = (NotificationEventTypeCodeType)Enum.Parse(typeof(NotificationEventTypeCodeType), notificationEvent, true),
                    EventEnable = (EnableCodeType)Enum.Parse(typeof(EnableCodeType), notificationEnable, true)
                });
                call.Execute();

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
