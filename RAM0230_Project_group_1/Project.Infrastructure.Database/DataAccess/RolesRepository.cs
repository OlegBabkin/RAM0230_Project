using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class RolesRepository : IRolesRepository
    {
        private KolledzDBContext context;

        public RolesRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Role entity)
        {
            this.context.Roles.Remove(entity);
        }

        public IQueryable<Role> FindBy(Expression<Func<Role, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<Role> GetAllEntries()
        {
            return this.context.Roles.AsQueryable<Role>();
        }

        public Role GetByKey(int key)
        {
            return this.context.Roles.FirstOrDefault(g => g.Id == key);
        }

        public void Insert(Role entity)
        {
            this.context.Roles.Add(entity);
        }

        public void Update(Role entity)
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
