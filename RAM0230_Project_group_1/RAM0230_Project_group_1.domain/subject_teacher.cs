//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RAM0230_Project_group_1.domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class subject_teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subject_teacher()
        {
            this.visits = new HashSet<visits>();
        }
    
        public int ID { get; set; }
        public string subject_code { get; set; }
        public int teacher_id { get; set; }
    
        public virtual subjects subjects { get; set; }
        public virtual users users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<visits> visits { get; set; }
    }
}