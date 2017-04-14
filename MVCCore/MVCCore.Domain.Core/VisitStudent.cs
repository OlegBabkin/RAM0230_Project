using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class VisitStudent
    {
        public int VisitId { get; set; }
        public string StudentCode { get; set; }

        public virtual Student StudentCodeNavigation { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
