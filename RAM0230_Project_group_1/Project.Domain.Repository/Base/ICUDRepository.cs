using System;

namespace Project.Domain.Repository.Base
{
    public interface ICUDRepository<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
