using Project.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Database.Connection
{
    public partial class KolledzDBContext : DbContext
    {
        public KolledzDBContext()
            : base("name=KolledzDB")
        {
        }
        public KolledzDBContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Oppevorm> Oppevorms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
