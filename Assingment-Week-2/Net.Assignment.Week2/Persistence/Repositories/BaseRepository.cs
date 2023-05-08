using Application.Repositories;
using Domain.Common;
using Persistence.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly BaseDbContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(BaseDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _entities.FirstOrDefault(expression);
        }

        public List<T> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            return expression is null ? _entities.ToList() : _entities.Where(expression).ToList();
        }

        public void Create(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = "System";

            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
