using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Contracts.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
}