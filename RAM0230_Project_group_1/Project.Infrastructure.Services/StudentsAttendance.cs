using AutoMapper;
using Project.Domain.Core;
using Project.Domain.Repository;
using Project.Infrastructure.DTO.Student;
using Project.Infrastructure.DTO.Subject;
using Project.Infrastructure.DTO.User;
using Project.Infrastructure.DTO.Visit;
using Project.Infrastructure.Services.Interfaces;
using Project.Infrastructure.Services.Validation;
using System;
using System.Collections.Generic;

namespace Project.Infrastructure.Services
{
    public class StudentsAttendance : IAttendanceService
    {
        IUnitOfWork Uow { get; set; }

        public StudentsAttendance(IUnitOfWork uow) { Uow = uow; }

        public IEnumerable<VisitDTO> GetVisits()
        {
            Mapper.Initialize(config => config.CreateMap<Visit, VisitDTO>()
                .ForMember("SubjectTitle", option => option.MapFrom(st => st.Subject.Title)));
            return Mapper.Map<IEnumerable<Visit>, List<VisitDTO>>(Uow.Visits.GetAllEntries());
        }

        public IEnumerable<StudentDTO> GetSubjectStudents(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<Student, StudentDTO>());
            return Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(Uow.Subjects.GetSubjectStudents(subject));
        }

        public IEnumerable<TeacherDTO> GetSubjectTeachers(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<User, TeacherDTO>());
            return Mapper.Map<IEnumerable<User>, List<TeacherDTO>>(Uow.Subjects.GetSubjectTeachers(subject));
        }

        public SubjectDTO GetSubject(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<Subject, SubjectDTO>());
            return Mapper.Map<Subject, SubjectDTO>(subject);
        }

        public void MakeAttendanceList(VisitDTO visit, string[] selectedStudents)
        {
            var newVisit = MakeVisit(visit, selectedStudents);
            Uow.Visits.Insert(newVisit);
            Uow.Save();
        }

        public void ChangeAttendanceList(VisitDTO visit, string[] selectedStudents)
        {
            var newVisit = MakeVisit(visit, selectedStudents);
            Uow.Visits.Update(newVisit);
            Uow.Save();
        }

        private Visit MakeVisit(VisitDTO visit, string[] selectedStudents)
        {
            var subject = ValidateSubject(visit.SubjectId);

            if (selectedStudents == null) { throw new ValidationException("Students list is empty or not exists", ""); }

            Visit visitEntity = new Visit
            {
                Date = DateTime.Now,
                LessonType = visit.LessonType,
                PairNumber = visit.PairNumber,
                SubjectId = subject.Id
            };
            visitEntity.Students.Clear();
            foreach (var item in selectedStudents)
            {
                Student s = Uow.Students.GetByKey(item);
                visitEntity.Students.Add(s);
            }

            return visitEntity;
        }

        private Subject ValidateSubject(int? subjectId)
        {
            if (subjectId == null) { throw new ValidationException("Subject ID is not presented", ""); }

            Subject subject = Uow.Subjects.GetByKey(subjectId.Value);
            if (subject == null) { throw new ValidationException("Subject not found", ""); }

            return subject;
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
