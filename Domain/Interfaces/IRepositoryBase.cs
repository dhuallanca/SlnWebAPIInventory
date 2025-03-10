using Domain.ResultHandler;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    /// <summary>
    /// Base interfaces for handle model events
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        Task<Result<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<bool>> UpdateByIdAsync(T entity);
        Task<Result<bool>> DeleteByIdAsync(int id);
        Task<Result<int>> InsertAsync(T entity);
    }
}
