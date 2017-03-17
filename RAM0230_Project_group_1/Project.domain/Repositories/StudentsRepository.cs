using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.domain.Repositories
{
    class StudentsRepository : IRepository<student>
    {
        KolledzDBConn context;

        public StudentsRepository()
        {
            this.context = new KolledzDBConn();
        }

        public StudentsRepository(KolledzDBConn db)
        {
            this.context = db;
        }
        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Delete(student entity)
        {
            this.context.students.Find(entity.code);
            this.context.students.Remove(entity);
        }

        public IQueryable<student> FindBy(Expression<Func<student, bool>> predicate)
        {
            return GetAllEntries().Where(predicate);
        }

        public IQueryable<student> GetAllEntries()
        {
            return this.context.students.AsQueryable<student>();
        }

        public void Insert(student entity)
        {
            this.context.students.Add(entity);
        }

        public void Update(student entity)
        {
            var oldEntity = context.students.Find(entity.code);
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
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
