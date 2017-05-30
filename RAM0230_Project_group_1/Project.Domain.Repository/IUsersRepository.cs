using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Domain.Repository
{
    public interface IUsersRepository : IBaseRepository<User>, IGetByKey<User, int>
    {
        IEnumerable<Subject_teacher> GetTeacherSubjects(User user);
        User FindUser(Expression<Func<User, bool>> predicate);
    }
}
