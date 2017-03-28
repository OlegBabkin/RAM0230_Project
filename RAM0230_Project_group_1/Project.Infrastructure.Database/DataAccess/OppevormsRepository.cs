using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class OppevormsRepository : IOppevormsRepository
    {
        private KolledzDBContext context;

        public OppevormsRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Oppevorm entity)
        {
            this.context.Oppevorms.Remove(entity);
        }

        public IQueryable<Oppevorm> FindBy(Expression<Func<Oppevorm, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<Oppevorm> GetAllEntries()
        {
            return this.context.Oppevorms.AsQueryable<Oppevorm>();
        }

        public Oppevorm GetByKey(int key)
        {
            return this.context.Oppevorms.FirstOrDefault(o => o.Id == key);
        }

        public void Insert(Oppevorm entity)
        {
            this.context.Oppevorms.Add(entity);
        }

        public void Update(Oppevorm entity)
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
