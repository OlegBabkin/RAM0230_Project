using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            SubjectGroup = new HashSet<SubjectGroup>();
        }

        public int Id { get; set; }
        public string GroupCode { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
    }
}
