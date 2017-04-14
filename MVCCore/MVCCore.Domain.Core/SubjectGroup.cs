using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class SubjectGroup
    {
        public int SubjectId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
