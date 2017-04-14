using System;
using System.Collections.Generic;

namespace MVCCore.Domain.Core
{
    public partial class User
    {
        public User()
        {
            SubjectTeacher = new HashSet<SubjectTeacher>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<SubjectTeacher> SubjectTeacher { get; set; }
        public virtual Role Role { get; set; }
    }
}
