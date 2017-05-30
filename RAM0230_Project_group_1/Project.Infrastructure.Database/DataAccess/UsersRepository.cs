using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

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

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.Where(predicate).ToList();
        }

        public User FindUser(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.FirstOrDefault(predicate);
        }

        public IEnumerable<User> GetAllEntries()
        {
            return this.context.Users;
        }

        public User GetByKey(int key)
        {
            return this.context.Users.FirstOrDefault(u => u.Id == key);
        }

        public IEnumerable<Subject_teacher> GetTeacherSubjects(User user)
        {
            return this.GetByKey(user.Id).Subject_teacher;
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
