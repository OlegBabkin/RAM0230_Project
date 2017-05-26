using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IGroupsRepository : IBaseRepository<Group>, IGetByKey<Group, int>
    {
        IEnumerable<Student> GetGroupStudents(Group group);
        IEnumerable<Subject> GetGroupSubjects(Group group);
    }
}
