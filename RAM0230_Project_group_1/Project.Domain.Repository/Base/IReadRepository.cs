using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Domain.Repository.Base
{
    public interface IReadRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAllEntries();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
