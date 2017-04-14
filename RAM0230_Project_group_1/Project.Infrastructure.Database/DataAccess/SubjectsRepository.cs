using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

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

        public IEnumerable<Subject> FindBy(Expression<Func<Subject, bool>> predicate)
        {
            return this.context.Subjects.Where(predicate).ToList();
        }

        public IEnumerable<Subject> GetAllEntries()
        {
            return this.context.Subjects;
        }

        public Subject GetByKey(int key)
        {
            return this.context.Subjects.FirstOrDefault(sb => sb.Id == key);
        }

        public IEnumerable<Group> GetSubjectGroups(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Groups;
        }

        public IEnumerable<Student> GetSubjectStudents(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Students;
        }

        public IEnumerable<User> GetSubjectTeachers(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Users.Where(u => u.Role.Name.Equals("teacher")).ToList();
        }

        public IEnumerable<Visit> GetSubjectVisits(Subject subject)
        {
            Subject sb = this.GetByKey(subject.Id);
            return sb.Visits;
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
