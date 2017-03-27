using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Linq;

namespace Project.Domain.Repository
{
    public interface IStudentsRepository : IBaseRepository<Student>, IGetByKey<Student, string>
    {
        IQueryable<Subject> GetStudentSubjects(Student student);
        IQueryable<Visit> GetStudentVisits(Student student);
    }
}
