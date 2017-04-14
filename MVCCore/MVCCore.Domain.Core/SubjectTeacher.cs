using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class SubjectTeacher
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual User Teacher { get; set; }
    }
}
