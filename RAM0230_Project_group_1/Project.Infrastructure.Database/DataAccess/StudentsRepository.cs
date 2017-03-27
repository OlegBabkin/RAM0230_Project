using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class StudentsRepository : IStudentsRepository
    {
        private KolledzDBContext context;

        public StudentsRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Student entity)
        {
            this.context.Students.Remove(entity);
        }

        public IQueryable<Student> FindBy(Expression<Func<Student, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<Student> GetAllEntries()
        {
            return this.context.Students.AsQueryable<Student>();
        }

        public Student GetByKey(string key)
        {
            return this.context.Students.FirstOrDefault(g => g.Id == key);
        }

        public IQueryable<Subject> GetStudentSubjects(Student student)
        {
            Student s = this.GetByKey(student.Code);
            return s.Subjects.AsQueryable<Subject>();
        }

        public IQueryable<Visit> GetStudentVisits(Student student)
        {
            Student s = this.GetByKey(student.Code);
            return s.Visits.AsQueryable<Visit>();
        }

        public void Insert(Student entity)
        {
            this.context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            var oldEntry = this.GetByKey(entity.Code);
            if (oldEntry != null)
            {
                this.context.Entry(oldEntry).CurrentValues.SetValues(entity);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StudentsRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
