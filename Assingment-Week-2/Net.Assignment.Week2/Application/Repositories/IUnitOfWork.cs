using Domain.Entities;

namespace Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Staff> StaffRepository { get; }
        void SaveChanges();
    }
}
