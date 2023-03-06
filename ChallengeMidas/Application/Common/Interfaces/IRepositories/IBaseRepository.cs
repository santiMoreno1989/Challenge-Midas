using System.Linq.Expressions;

namespace Application.Common.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
