using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface IModeOfStudy : IBaseRepository<ModeOfStudy>, IGetByKey<ModeOfStudy, int>
    {
    }
}
