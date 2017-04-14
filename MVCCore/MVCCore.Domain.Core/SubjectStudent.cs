using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class SubjectStudent
    {
        public int SubjectId { get; set; }
        public string StudentCode { get; set; }

        public virtual Student StudentCodeNavigation { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
