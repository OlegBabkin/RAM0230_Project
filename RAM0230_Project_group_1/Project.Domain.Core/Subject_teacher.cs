namespace Project.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kolledz.Subject_teacher")]
    public partial class Subject_teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject_teacher()
        {
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int TeacherId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual User User { get; set; }
    }
}
