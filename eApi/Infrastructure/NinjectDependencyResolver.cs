using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;
using eApi.Models;
using eApi.Domain;
using eApi.Controllers;

using eApi.Domain.Integrations.eBay;

using eBay.Service.Core.Sdk;
using eBay.Service.Call;

namespace eApi.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel k)
        {
            kernel = k;
            addBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        void addBindings()
        {
            kernel.Bind<ITransactionRepository>().To<TransactionRepositoryEF>();
            kernel.Bind<eBayApi>().To<eBayApi>();
        }
    }
}