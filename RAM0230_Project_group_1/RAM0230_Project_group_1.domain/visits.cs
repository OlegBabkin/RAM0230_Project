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
    
    public partial class visits
    {
        public int ID { get; set; }
        public string student_code { get; set; }
        public System.DateTime date { get; set; }
        public string lesson_type { get; set; }
        public Nullable<int> paar_nr { get; set; }
        public int subject_teacher_id { get; set; }
    
        public virtual students students { get; set; }
        public virtual subject_teacher subject_teacher { get; set; }
    }
}
