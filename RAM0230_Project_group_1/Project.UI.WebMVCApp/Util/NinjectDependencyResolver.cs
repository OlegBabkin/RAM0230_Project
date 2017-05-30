using Ninject;
using Project.Domain.Repository;
using Project.Infrastructure.Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("connectionString", "name=KolledzDB");
        }
    }
}