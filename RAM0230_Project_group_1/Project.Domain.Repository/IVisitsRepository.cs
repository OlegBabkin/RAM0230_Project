using Project.Domain.Core;
using Project.Domain.Repository.Base;
using System.Collections.Generic;

namespace Project.Domain.Repository
{
    public interface IVisitsRepository : IBaseRepository<Visit>, IGetByKey<Visit, int>
    {
        IEnumerable<Student> GetStudentVisits(Visit visit);
    }
}
