using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Linq;

namespace Project.Domain.Repository
{
    public interface ISubjectsRepository : IBaseRepository<Subject>, IGetByKey<Subject, int>
    {
        IQueryable<Visit> GetSubjectVisits();
        IQueryable<Group> GetSubjectGroups();
        IQueryable<Student> GetSubjectStudents();
        IQueryable<User> GetSubjectTeachers();
    }
}
