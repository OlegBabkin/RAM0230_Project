using Project.Domain.Repository;
using System;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        // Context
        private KolledzDBContext context;

        // Repositories
        private IGroupsRepository groupsRepository;
        private IModeOfStudy modesOfStudyRepository;
        private IRolesRepository rolesRepository;
        private IStudentsRepository studentsRepository;
        private ISubjectsRepository subjectsRepository;
        private ISubjectTeachersRepository subjectTeachersRepository;
        private IUsersRepository usersRepository;
        private IVisitsRepository visitsRepository;

        public UnitOfWork(KolledzDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException("DB context is missing!");
        }

        public UnitOfWork(string connectionString)
        {
            context = new KolledzDBContext(connectionString);
        }

        // Properties
        public IGroupsRepository Groups
        {
            get
            {
                if (groupsRepository == null) { groupsRepository = new GroupsRepository(context); }
                return groupsRepository;
            }
        }

        public IModeOfStudy ModesOfStudy
        {
            get
            {
                if (modesOfStudyRepository == null) { modesOfStudyRepository = new ModesOfStudyRepository(context); }
                return modesOfStudyRepository;
            }
        }

        public IRolesRepository Roles
        {
            get
            {
                if (rolesRepository == null) { rolesRepository = new RolesRepository(context); }
                return rolesRepository;
            }
        }

        public IStudentsRepository Students
        {
            get
            {
                if (studentsRepository == null) { studentsRepository = new StudentsRepository(context); }
                return studentsRepository;
            }
        }

        public ISubjectsRepository Subjects
        {
            get
            {
                if (subjectsRepository == null) { subjectsRepository = new SubjectsRepository(context); }
                return subjectsRepository;
            }
        }

        public ISubjectTeachersRepository SubjectTeachers
        {
            get
            {
                if (subjectTeachersRepository == null) { subjectTeachersRepository = new SubjectTeachersRepository(context); }
                return subjectTeachersRepository;
            }
        }

        public IUsersRepository Users
        {
            get
            {
                if (usersRepository == null) { usersRepository = new UsersRepository(context); }
                return usersRepository;
            }
        }

        public IVisitsRepository Visits
        {
            get
            {
                if (visitsRepository == null) { visitsRepository = new VisitsRepository(context); }
                return visitsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
