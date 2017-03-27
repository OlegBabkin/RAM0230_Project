using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface IGroupsRepository : IBaseRepository<Group>, IGetByKey<Group, int>
    {
    }
}
