using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<T> where T:Entity
{
    Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter =null);
    Task<T?> GetByFilter(Expression<Func<T,bool>> filter);
    Task<T> AddAsync(T entity);
    Task<T?> DeleteAsync(int id);
    Task<T> UpdateAsync(T entity);
}
