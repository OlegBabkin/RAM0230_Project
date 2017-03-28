using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private KolledzDBContext context;

        public SubjectsRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Subject entity)
        {
            this.context.Subjects.Remove(entity);
        }

        public IQueryable<Subject> FindBy(Expression<Func<Subject, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<Subject> GetAllEntries()
        {
            return this.context.Subjects.AsQueryable<Subject>();
        }

        public Subject GetByKey(int key)
        {
            return this.context.Subjects.FirstOrDefault(sb => sb.Id == key);
        }

        public IQueryable<Group> GetSubjectGroups(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Groups.AsQueryable<Group>();
        }

        public IQueryable<Student> GetSubjectStudents(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Students.AsQueryable<Student>();
        }

        public IQueryable<User> GetSubjectTeachers(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Users.Where(u => u.Role.Name.Equals("teacher")).AsQueryable<User>();
        }

        public IQueryable<Visit> GetSubjectVisits(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Visits.AsQueryable<Visit>();
        }

        public void Insert(Subject entity)
        {
            this.context.Subjects.Add(entity);
        }

        public void Update(Subject entity)
        {
            var oldEntry = this.GetByKey(entity.Id);
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
