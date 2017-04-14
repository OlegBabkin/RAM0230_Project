using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface ISubjectsRepository : IBaseRepository<Subject>, IGetByKey<Subject, int>
    {
        IEnumerable<Visit> GetSubjectVisits(Subject subject);
        IEnumerable<Group> GetSubjectGroups(Subject subject);
        IEnumerable<Student> GetSubjectStudents(Subject subject);
        IEnumerable<User> GetSubjectTeachers(Subject subject);
    }
}
