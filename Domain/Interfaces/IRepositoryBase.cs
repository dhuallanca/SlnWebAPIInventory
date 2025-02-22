
namespace Domain.Interfaces
{
    /// <summary>
    /// Base interfaces for handle model events
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void DeleteById(int id);
        void UpdateById(T entity);
        void UpdateByIdAsync(T entity);
        void DeleteByIdAsync(int id);
        void InsertById(T entity);
        void InsertByIdAsync(T entity);
    }
}
