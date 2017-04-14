using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectGroup = new HashSet<SubjectGroup>();
            SubjectStudent = new HashSet<SubjectStudent>();
            SubjectTeacher = new HashSet<SubjectTeacher>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string Lektorat { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Semester { get; set; }
        public decimal? LectureHours { get; set; }
        public decimal? PracticeHours { get; set; }
        public decimal? ExercisesHours { get; set; }
        public int ModeOfStudyId { get; set; }
        public string Language { get; set; }

        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
        public virtual ICollection<SubjectStudent> SubjectStudent { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeacher { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ModeOfStudy ModeOfStudy { get; set; }
    }
}
