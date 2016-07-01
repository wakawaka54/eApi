using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Data.Entity;

using Api.Infrastructure;
using eApi.Domain;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(new Ninject.StandardKernel());

            Database.SetInitializer<eDbContext>(new DropCreateDatabaseIfModelChanges<eDbContext>());
        }
    }
}
