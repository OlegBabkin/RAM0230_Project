using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.domain.Repositories
{
    class SubjectsRepository : IRepository<subject>
    {
        KolledzDBConn context;

        public SubjectsRepository()
        {
            this.context = new KolledzDBConn();
        }

        public SubjectsRepository(KolledzDBConn db)
        {
            this.context = db;
        }
        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Delete(subject entity)
        {
            this.context.subjects.Find(entity.ID);
            this.context.subjects.Remove(entity);
        }

        public IQueryable<subject> FindBy(Expression<Func<subject, bool>> predicate)
        {
            return GetAllEntries().Where(predicate);
        }

        public IQueryable<subject> GetAllEntries()
        {
            return this.context.subjects.AsQueryable<subject>();
        }

        public void Insert(subject entity)
        {
            this.context.subjects.Add(entity);
        }

        public void Update(subject entity)
        {
            var oldEntity = context.subjects.Find(entity.ID);
            this.context.Entry(oldEntity).CurrentValues.SetValues(entity);
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
                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SubjectsRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
