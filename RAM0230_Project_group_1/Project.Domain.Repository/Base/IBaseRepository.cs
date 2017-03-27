using System;

namespace Project.Domain.Repository.Base
{
    public interface IBaseRepository<T> : IReadRepository<T>, ICUDRepository<T>, IDisposable where T : class
    {
    }
}
