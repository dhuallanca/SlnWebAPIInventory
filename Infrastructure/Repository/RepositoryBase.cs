using Domain.Interfaces;
using Domain.ResultHandler;
using Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryBase<T>(InventoryDBContext dbContext, ICancellationTokenService cancellationToken) : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> dbSet = dbContext.Set<T>();
        public async Task<Result<bool>> DeleteByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return Result<bool>.Failure(GeneralError.DoesntExists);
            }
            dbSet.Remove(entity);
            return Result<bool>.Success(true);
        }

        public Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<int>> InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            var id = await dbContext.SaveChangesAsync(cancellationToken.CancellationToken);
            return Result<int>.Success(id);
        }

        public async Task<Result<bool>> UpdateByIdAsync(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken.CancellationToken);
            return Result<bool>.Success(true);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
