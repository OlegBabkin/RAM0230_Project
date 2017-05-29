using System.Collections.Generic;
using Project.Infrastructure.DTO;

namespace Project.Infrastructure.Services.Interfaces
{
    public interface IAttendanceService
    {
        void MakeAttendanceList(VisitDTO visit, string[] selectedStudents);
        void ChangeAttendanceList(VisitDTO visit, string[] selectedStudents);
        IEnumerable<UserDTO> GetTeachers();
        SubjectDTO GetSubject(int? subjectId);
        IEnumerable<SubjectDTO> GetSubjects();
        VisitDTO GetVisit(int? visitId);
        IEnumerable<VisitDTO> GetVisits();
        IEnumerable<SubjectTeacherDTO> GetSubjectTeachers(int? subjectId);
        IEnumerable<StudentDTO> GetSubjectStudents(int? subjectId);
        void Dispose();
    }
}
