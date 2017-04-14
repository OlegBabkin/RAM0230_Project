using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IUsersRepository : IBaseRepository<User>, IGetByKey<User, int>
    {
        IEnumerable<Subject> GetTeacherSubjects(User user);
    }
}
