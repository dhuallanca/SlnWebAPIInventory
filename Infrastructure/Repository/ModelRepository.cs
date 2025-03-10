using Domain.Entities;
using Domain.Interfaces;
using Domain.ResultHandler;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    /// <summary>
    /// Repository implement IRepository
    /// Works with Data access
    /// </summary>
    public class ModelRepository : IModelRepository, IDisposable
    {
        private InventoryDBContext _dbContext;
        public ModelRepository(InventoryDBContext context)
        {
            _dbContext = context;
        }

        public Task<Model> CreateModel()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Model>> GetModels()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Model>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateByIdAsync(Model entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> InsertAsync(Model entity)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<Result<IEnumerable<Model>>> GetAllAsync(Expression<Func<Model, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
