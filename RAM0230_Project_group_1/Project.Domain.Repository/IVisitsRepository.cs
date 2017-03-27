using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface IVisitsRepository : IBaseRepository<Visit>, IGetByKey<Visit, int>
    {
    }
}
