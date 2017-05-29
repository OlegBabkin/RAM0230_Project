using AutoMapper;
using Project.Domain.Core;
using Project.Domain.Repository;
using Project.Infrastructure.DTO;
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

        public IEnumerable<UserDTO> GetTeachers()
        {
            Mapper.Initialize(config => config.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<TeacherDTO>>(Uow.Users.FindBy(u => u.Role.Name.Equals("teacher")));
        }

        public VisitDTO GetVisit(int? visitId)
        {
            var visit = ValidateVisit(visitId);

            Mapper.Initialize(config => config.CreateMap<Visit, VisitDTO>());
            return Mapper.Map<Visit, VisitDTO>(visit);
        }

        public IEnumerable<VisitDTO> GetVisits()
        {
            Mapper.Initialize(config => config.CreateMap<Visit, VisitDTO>()
                .ForMember("SubjectTitle", option => option.MapFrom(st => st.Subject.Title)));
            return Mapper.Map<IEnumerable<Visit>, List<VisitDTO>>(Uow.Visits.GetAllEntries());
        }

        public SubjectDTO GetSubject(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<Subject, SubjectDTO>());
            return Mapper.Map<Subject, SubjectDTO>(subject);
        }

        public IEnumerable<SubjectDTO> GetSubjects()
        {
            Mapper.Initialize(config => config.CreateMap<Subject, SubjectDTO>()
               .ForMember("ModeOfStudyName", option => option.MapFrom(sb => sb.ModeOfStudy.Name)));
            return Mapper.Map<IEnumerable<Subject>, List<SubjectDTO>>(Uow.Subjects.GetAllEntries());
        }

        public IEnumerable<StudentDTO> GetSubjectStudents(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<Student, StudentDTO>());
            return Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(Uow.Subjects.GetSubjectStudents(subject));
        }

        public IEnumerable<UserDTO> GetSubjectTeachers(int? subjectId)
        {
            var subject = ValidateSubject(subjectId);

            Mapper.Initialize(config => config.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<TeacherDTO>>(Uow.Subjects.GetSubjectTeachers(subject));
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

        private Visit ValidateVisit(int? visitId)
        {
            if (visitId == null) { throw new ValidationException("Visit ID is not presented", ""); }

            Visit visit = Uow.Visits.GetByKey(visitId.Value);
            if (visit == null) { throw new ValidationException("Visit not found", ""); }

            return visit;
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
