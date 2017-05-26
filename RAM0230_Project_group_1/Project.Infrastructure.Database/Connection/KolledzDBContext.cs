namespace Project.Infrastructure.Database.Connection
{
    using Project.Domain.Core;
    using System.Data.Entity;

    public partial class KolledzDBContext : DbContext
    {
        public KolledzDBContext() : base("name=KolledzDBContext") { }
        public KolledzDBContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<ModeOfStudy> ModeOfStudies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject_teacher> Subject_teacher { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .Property(e => e.GroupCode)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("Subject_group", "kolledz").MapLeftKey("GroupId").MapRightKey("SubjectId"));

            modelBuilder.Entity<ModeOfStudy>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.ModeOfStudy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModeOfStudy>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.ModeOfStudy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Students)
                .Map(m => m.ToTable("Subject_student", "kolledz").MapLeftKey("StudentCode").MapRightKey("SubjectId"));

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Visits)
                .WithMany(e => e.Students)
                .Map(m => m.ToTable("Visit_student", "kolledz").MapLeftKey("StudentCode").MapRightKey("VisitId"));

            modelBuilder.Entity<Subject_teacher>()
                .HasMany(e => e.Visits)
                .WithRequired(e => e.Subject_teacher)
                .HasForeignKey(e => e.Subject_Techer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Lektorat)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .Property(e => e.Semester)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.LectureHours)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Subject>()
                .Property(e => e.PracticeHours)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Subject>()
                .Property(e => e.ExercisesHours)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Subject_teacher)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subject_teacher)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.TeacherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.LessonType)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
