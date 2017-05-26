namespace Project.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kolledz.Subjects")]
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            Subject_teacher = new HashSet<Subject_teacher>();
            Groups = new HashSet<Group>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [StringLength(3)]
        public string Lektorat { get; set; }

        [Required]
        [StringLength(9)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1)]
        public string Semester { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LectureHours { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PracticeHours { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExercisesHours { get; set; }

        public int ModeOfStudyId { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        public virtual ModeOfStudy ModeOfStudy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject_teacher> Subject_teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
