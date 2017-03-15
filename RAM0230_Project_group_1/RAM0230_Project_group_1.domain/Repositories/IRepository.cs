using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RAM0230_Project_group_1.domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAllEntries();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicare);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Commit();
    }
}
