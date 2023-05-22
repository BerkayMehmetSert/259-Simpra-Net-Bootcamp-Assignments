using System.Linq.Expressions;
using Application.Contracts.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Context;

namespace Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly BaseDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(BaseDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public void Create(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = "System";
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = "System";
        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public T Get(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = _entities;

        if (include is not null)
        {
            queryable = include(queryable);
        }

        return queryable.FirstOrDefault(predicate);
    }

    public List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = _entities;

        if (include is not null)
        {
            queryable = include(queryable);
        }

        if (predicate is not null)
        {
            queryable = queryable.Where(predicate);
        }

        return queryable.ToList();
    }
}