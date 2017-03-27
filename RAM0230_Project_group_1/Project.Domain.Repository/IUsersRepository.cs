using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Linq;

namespace Project.Domain.Repository
{
    public interface IUsersRepository : IBaseRepository<User>, IGetByKey<User, int>
    {
        IQueryable<Subject> GetTeacherSubjects(User user);
    }
}
