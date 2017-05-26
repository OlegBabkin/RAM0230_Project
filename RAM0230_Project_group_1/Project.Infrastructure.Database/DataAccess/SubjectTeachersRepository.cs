using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

namespace Project.Infrastructure.Database.DataAccess
{
    class SubjectTeachersRepository : ISubjectTeachersRepository
    {
        private KolledzDBContext context;

        public SubjectTeachersRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Subject_teacher entity)
        {
            this.context.Subject_teacher.Remove(entity);
        }

        public IEnumerable<Subject_teacher> FindBy(Expression<Func<Subject_teacher, bool>> predicate)
        {
            return this.context.Subject_teacher.Where(predicate).ToList();
        }

        public IEnumerable<Subject_teacher> GetAllEntries()
        {
            return this.context.Subject_teacher;
        }

        public Subject_teacher GetByKey(int key)
        {
            return this.context.Subject_teacher.FirstOrDefault(sb => sb.Id == key);
        }

        public IEnumerable<Visit> GetSubjectTeacherVisits(Subject_teacher subjectTeacher)
        {
            return this.GetByKey(subjectTeacher.Id).Visits;
        }

        public void Insert(Subject_teacher entity)
        {
            this.context.Subject_teacher.Add(entity);
        }

        public void Update(Subject_teacher entity)
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
