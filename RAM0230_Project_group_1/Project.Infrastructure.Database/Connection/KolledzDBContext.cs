using Project.Domain.Core;
using System.Data.Entity;

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
        public virtual DbSet<ModeOfStudy> ModesOfStudy { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
