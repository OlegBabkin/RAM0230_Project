using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Domain.Repository.Base
{
    public interface IReadRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllEntries();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
