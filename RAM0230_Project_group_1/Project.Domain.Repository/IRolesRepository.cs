using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface IRolesRepository : IBaseRepository<Role>, IGetByKey<Role, int>
    {
    }
}
