using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class VisitsRepository : IVisitsRepository
    {
        private KolledzDBContext context;

        public VisitsRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Visit entity)
        {
            this.context.Visits.Remove(entity);
        }

        public IQueryable<Visit> FindBy(Expression<Func<Visit, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<Visit> GetAllEntries()
        {
            return this.context.Visits.AsQueryable<Visit>();
        }

        public Visit GetByKey(int key)
        {
            return this.context.Visits.FirstOrDefault(v => v.Id == key);
        }

        public IQueryable<Student> GetStudentVisits(Visit visit)
        {
            Visit v = this.GetByKey(visit.Id);
            return v.Students.AsQueryable<Student>();
        }

        public void Insert(Visit entity)
        {
            this.context.Visits.Add(entity);
        }

        public void Update(Visit entity)
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
