using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IRolesRepository : IBaseRepository<Role>, IGetByKey<Role, int>
    {
        IEnumerable<User> GetRoleUsers(Role role);
    }
}
