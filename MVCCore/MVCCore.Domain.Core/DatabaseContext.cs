using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCCore.Domain.Core
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<ModeOfStudy> ModeOfStudy { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroup { get; set; }
        public virtual DbSet<SubjectStudent> SubjectStudent { get; set; }
        public virtual DbSet<SubjectTeacher> SubjectTeacher { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VisitStudent> VisitStudent { get; set; }
        public virtual DbSet<Visits> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"data source=www.vk.edu.ee;initial catalog=db_OlegB;user id=t160200ctf;password=t160200ctf;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups", "kolledz");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasColumnType("nchar(6)");
            });

            modelBuilder.Entity<ModeOfStudy>(entity =>
            {
                entity.ToTable("ModeOfStudy", "kolledz");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "kolledz");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__students__357D4CF842B7FBC8");

                entity.ToTable("Students", "kolledz");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_student_group");

                entity.HasOne(d => d.ModeOfStudy)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ModeOfStudyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_student_oppevorm");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.GroupId })
                    .HasName("pk_subject_group");

                entity.ToTable("Subject_group", "kolledz");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubjectGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_group_group");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectGroup)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_group_subject");
            });

            modelBuilder.Entity<SubjectStudent>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.StudentCode })
                    .HasName("pk_subject_student");

                entity.ToTable("Subject_student", "kolledz");

                entity.Property(e => e.StudentCode).HasMaxLength(10);

                entity.HasOne(d => d.StudentCodeNavigation)
                    .WithMany(p => p.SubjectStudent)
                    .HasForeignKey(d => d.StudentCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_student_student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectStudent)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_student_subject");
            });

            modelBuilder.Entity<SubjectTeacher>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.TeacherId })
                    .HasName("pk_subject_teacher");

                entity.ToTable("Subject_teacher", "kolledz");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectTeacher)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_teacher_subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectTeacher)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_teacher_user");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subjects", "kolledz");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("nchar(9)");

                entity.Property(e => e.ExercisesHours).HasColumnType("numeric");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.LectureHours).HasColumnType("numeric");

                entity.Property(e => e.Lektorat).HasColumnType("nchar(3)");

                entity.Property(e => e.PracticeHours).HasColumnType("numeric");

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ModeOfStudy)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ModeOfStudyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_subject_oppevorm");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "kolledz");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname).HasMaxLength(100);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_user_role");
            });

            modelBuilder.Entity<VisitStudent>(entity =>
            {
                entity.HasKey(e => new { e.VisitId, e.StudentCode })
                    .HasName("pk_Visit_student");

                entity.ToTable("Visit_student", "kolledz");

                entity.Property(e => e.StudentCode).HasMaxLength(10);

                entity.HasOne(d => d.StudentCodeNavigation)
                    .WithMany(p => p.VisitStudent)
                    .HasForeignKey(d => d.StudentCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Visit_student_student");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitStudent)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Visit_student_visit");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visits", "kolledz");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.LessonType).HasColumnType("char(1)");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__visits__subject___6D9742D9");
            });
        }
    }
}