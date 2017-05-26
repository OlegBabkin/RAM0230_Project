using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IModeOfStudy : IBaseRepository<ModeOfStudy>, IGetByKey<ModeOfStudy, int>
    {
        IEnumerable<Student> GetModeOfStudyStudents(ModeOfStudy modeOfStudy);
        IEnumerable<Subject> GetModeOfStudySubjects(ModeOfStudy modeOfStudy);
    }
}
