using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface IOppevormsRepository : IBaseRepository<Oppevorm>, IGetByKey<Oppevorm, int>
    {
    }
}
