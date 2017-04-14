using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

namespace Project.Infrastructure.Database.DataAccess
{
    public class GroupsRepository : IGroupsRepository
    {
        private KolledzDBContext context;

        public GroupsRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(Group entity)
        {
            this.context.Groups.Remove(entity);
        }

        public IEnumerable<Group> FindBy(Expression<Func<Group, bool>> predicate)
        {
            return this.context.Groups.Where(predicate).ToList();
        }

        public IEnumerable<Group> GetAllEntries()
        {
            return this.context.Groups;
        }

        public Group GetByKey(int key)
        {
            return this.context.Groups.FirstOrDefault(g => g.Id == key);
        }

        public void Insert(Group entity)
        {
            this.context.Groups.Add(entity);
        }

        public void Update(Group entity)
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
