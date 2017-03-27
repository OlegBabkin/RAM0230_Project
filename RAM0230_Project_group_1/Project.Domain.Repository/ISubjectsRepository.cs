using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Linq;

namespace Project.Domain.Repository
{
    public interface ISubjectsRepository : IBaseRepository<Subject>, IGetByKey<Subject, int>
    {
        IQueryable<Visit> GetSubjectVisits(Subject subject);
        IQueryable<Group> GetSubjectGroups(Subject subject);
        IQueryable<Student> GetSubjectStudents(Subject subject);
        IQueryable<User> GetSubjectTeachers(Subject subject);
    }
}
