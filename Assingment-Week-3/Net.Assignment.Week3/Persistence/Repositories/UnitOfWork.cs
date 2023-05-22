using Application.Contracts.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    private bool _disposed;
    
    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
        CategoryRepository = new BaseRepository<Category>(context);
        ProductRepository = new BaseRepository<Product>(context);
    }
    
    public IBaseRepository<Category> CategoryRepository { get; }
    public IBaseRepository<Product> ProductRepository { get; }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    private void Clean(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
        GC.SuppressFinalize(this);
    }
    public void Dispose()
    {
        Clean(true);
    }
}