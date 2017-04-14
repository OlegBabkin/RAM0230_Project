using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class ModeOfStudy
    {
        public ModeOfStudy()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
