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
            : base("metadata = res://*/KolledzModel.csdl|res://*/KolledzModel.ssdl|res://*/KolledzModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=www.vk.edu.ee;initial catalog=db_OlegB;user id=t160200ctf;password=t160200ctf;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient")
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
