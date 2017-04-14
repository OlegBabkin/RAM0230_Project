using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class Student
    {
        public Student()
        {
            SubjectStudent = new HashSet<SubjectStudent>();
            VisitStudent = new HashSet<VisitStudent>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int ModeOfStudyId { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }

        public virtual ICollection<SubjectStudent> SubjectStudent { get; set; }
        public virtual ICollection<VisitStudent> VisitStudent { get; set; }
        public virtual Group Group { get; set; }
        public virtual ModeOfStudy ModeOfStudy { get; set; }
    }
}
