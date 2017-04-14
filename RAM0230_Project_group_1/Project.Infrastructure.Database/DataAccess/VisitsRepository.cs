using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

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

        public IEnumerable<Visit> FindBy(Expression<Func<Visit, bool>> predicate)
        {
            return this.context.Visits.Where(predicate).ToList();
        }

        public IEnumerable<Visit> GetAllEntries()
        {
            return this.context.Visits;
        }

        public Visit GetByKey(int key)
        {
            return this.context.Visits.FirstOrDefault(v => v.Id == key);
        }

        public IEnumerable<Student> GetStudentVisits(Visit visit)
        {
            Visit v = this.GetByKey(visit.Id);
            return v.Students;
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
