using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IStudentsRepository : IBaseRepository<Student>, IGetByKey<Student, string>
    {
        IEnumerable<Subject> GetStudentSubjects(Student student);
        IEnumerable<Visit> GetStudentVisits(Student student);
    }
}
