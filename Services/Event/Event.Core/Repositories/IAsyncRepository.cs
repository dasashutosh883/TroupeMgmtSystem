using Event.Core.Common;
using System.Linq.Expressions;

namespace Event.Core.Repositories
{
    public interface IAsyncRepository<T,Tkey> where T: BaseEntity<Tkey>
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(Tkey id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
}