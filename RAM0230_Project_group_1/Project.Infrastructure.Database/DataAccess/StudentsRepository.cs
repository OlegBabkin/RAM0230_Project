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
            return this.context.Students.FirstOrDefault(s => s.Code == key);
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
