using Ninject.Modules;
using Project.Domain.Repository;
using Project.Infrastructure.Database.DataAccess;

namespace Project.Infrastructure.Services.Util
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
