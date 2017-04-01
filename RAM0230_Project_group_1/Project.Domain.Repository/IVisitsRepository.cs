using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Linq;

namespace Project.Domain.Repository
{
    public interface IVisitsRepository : IBaseRepository<Visit>, IGetByKey<Visit, int>
    {
        IQueryable<Student> GetStudentVisits(Visit visit);
    }
}
