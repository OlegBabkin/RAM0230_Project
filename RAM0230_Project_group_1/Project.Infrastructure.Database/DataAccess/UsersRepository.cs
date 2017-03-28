using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        private KolledzDBContext context;

        public UsersRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(User entity)
        {
            this.context.Users.Remove(entity);
        }

        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<User> GetAllEntries()
        {
            return this.context.Users.AsQueryable<User>();
        }

        public User GetByKey(int key)
        {
            return this.context.Users.FirstOrDefault(u => u.Id == key);
        }

        public IQueryable<Subject> GetTeacherSubjects(User user)
        {
            User s = this.GetByKey(user.Id);
            return s.Subjects.AsQueryable<Subject>();
        }

        public void Insert(User entity)
        {
            this.context.Users.Add(entity);
        }

        public void Update(User entity)
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
