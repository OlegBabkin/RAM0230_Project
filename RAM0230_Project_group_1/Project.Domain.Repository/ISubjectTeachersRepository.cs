using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Core;
using Project.Domain.Repository.Base;

namespace Project.Domain.Repository
{
    public interface ISubjectTeachersRepository : IBaseRepository<Subject_teacher>, IGetByKey<Subject_teacher, int>
    {
        IEnumerable<Visit> GetSubjectTeacherVisits(Subject_teacher subjectTeacher);
    }
}
