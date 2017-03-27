using Project.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Core;
using System.Linq.Expressions;

namespace Project.Infrastructure.Database.DataAccess
{
    public class GroupsRepository : IGroupsRepository
    {
        
        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> FindBy(Expression<Func<Group, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> GetAllEntries()
        {
            throw new NotImplementedException();
        }

        public Group GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void Insert(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Group entity)
        {
            throw new NotImplementedException();
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
        // ~GroupsRepository() {
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
