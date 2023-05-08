using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;

        public IBaseRepository<Staff> StaffRepository { get; private set; }

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
            StaffRepository = new BaseRepository<Staff>(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
