namespace Project.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kolledz.Visits")]
    public partial class Visit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visit()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        [StringLength(1)]
        public string LessonType { get; set; }

        public int? PairNumber { get; set; }

        public int Subject_Techer_Id { get; set; }

        public virtual Subject_teacher Subject_teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
