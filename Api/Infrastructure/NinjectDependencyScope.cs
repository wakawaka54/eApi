using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Http;

using Ninject.Syntax;
using Ninject.Activation;
using Ninject.Parameters;

namespace Api.Infrastructure
{
    public class NinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot resolutionRoot;

        public NinjectDependencyScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if(disposable != null) { disposable.Dispose(); }
            resolutionRoot = null;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }
    }
}