using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Http;

using Ninject;

using eApi.Domain;
using eApi.Domain.Integrations.eBay;

namespace Api.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernal; 

        public NinjectDependencyResolver(IKernel k)
            :base(k)
        {
            kernal = k;
            addBindings();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernal.BeginBlock());
        }

        void addBindings()
        {
            kernal.Bind<ITransactionRepository>().To<TransactionRepositoryEF>();
            kernal.Bind<eBayApi>().To<eBayApi>();
        }
    }
}