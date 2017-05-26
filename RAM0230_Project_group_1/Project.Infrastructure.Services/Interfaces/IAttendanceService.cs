using Project.Infrastructure.DTO.User;
using Project.Infrastructure.DTO.Subject;
using Project.Infrastructure.DTO.Visit;
using System.Collections.Generic;
using Project.Infrastructure.DTO.Student;

namespace Project.Infrastructure.Services.Interfaces
{
    public interface IAttendanceService
    {
        void MakeAttendanceList(VisitDTO visit, string[] selectedStudents);
        void ChangeAttendanceList(VisitDTO visit, string[] selectedStudents);
        IEnumerable<TeacherDTO> GetTeachers();
        SubjectDTO GetSubject(int? subjectId);
        IEnumerable<SubjectDTO> GetSubjects();
        VisitDTO GetVisit(int? visitId);
        IEnumerable<VisitDTO> GetVisits();
        IEnumerable<TeacherDTO> GetSubjectTeachers(int? subjectId);
        IEnumerable<StudentDTO> GetSubjectStudents(int? subjectId);
        void Dispose();
    }
}
