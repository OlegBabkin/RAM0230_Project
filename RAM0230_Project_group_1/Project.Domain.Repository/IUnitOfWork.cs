using System;

namespace Project.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupsRepository Groups { get; }
        IOppevormsRepository Oppevorms { get; }
        IRolesRepository Roles { get; }
        IStudentsRepository Students { get; }
        ISubjectsRepository Subjects { get; }
        IUsersRepository Users { get; }
        IVisitsRepository Visits { get; }

        void Save();
    }
}
