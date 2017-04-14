using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class Visit
    {
        public Visit()
        {
            VisitStudent = new HashSet<VisitStudent>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LessonType { get; set; }
        public int? PairNumber { get; set; }
        public int? SubjectId { get; set; }

        public virtual ICollection<VisitStudent> VisitStudent { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
