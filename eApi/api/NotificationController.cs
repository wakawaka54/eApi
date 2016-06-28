using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using eBay.Service.Core;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;

namespace eApi.api
{
    public class NotificationController : ApiController
    {
        ApiContext context;

        public NotificationController(ApiContext c)
        {
            context = c;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]string notification, [FromBody]string enable)
        {
            NotificationEventTypeCodeType not = (NotificationEventTypeCodeType)Enum.Parse(typeof(NotificationEventTypeCodeType), notification);
            EnableCodeType en = (EnableCodeType)Enum.Parse(typeof(EnableCodeType), enable);

            SetNotificationPreferencesCall call = new SetNotificationPreferencesCall(context);
            call.UserDeliveryPreferenceList = new NotificationEnableTypeCollection();
            call.UserDeliveryPreferenceList.Add(new NotificationEnableType()
            {
                EventType = not,
                EventEnable = en
            });

            return Ok();
        }
    }
}
