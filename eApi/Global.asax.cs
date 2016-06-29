using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

using System.Data.Entity;
using eApi.Domain;

namespace eApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new eApi.Infrastructure.NinjectDependencyResolver(new Ninject.StandardKernel()));

            Database.SetInitializer<eDbContext>(new DropCreateDatabaseIfModelChanges<eDbContext>());
        }
    }
}