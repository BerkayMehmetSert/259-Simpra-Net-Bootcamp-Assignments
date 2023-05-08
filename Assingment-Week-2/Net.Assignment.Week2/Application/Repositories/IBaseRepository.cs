using Domain.Common;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>>? expression = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
