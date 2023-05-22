using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Category> CategoryRepository { get; }
    IBaseRepository<Product> ProductRepository { get; }
    void SaveChanges();
}