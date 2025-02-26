using Domain.Entities.Identity;
using Domain.Interfaces;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Identity
{
    public class UserRepository(InventoryDBContext _dbContext, ICancellationTokenService cancellationToken) : IUserRepository, IDisposable
    {
        public async Task<Result<User>> Authenticate(string userName, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == userName &&  u.IsActive == true, cancellationToken.CancellationToken);
            if (user == null) {
                return Result<User>.Failure(UserBehavior.UserInvalid);
            }
            return Result<User>.Success(user);
        }
        public Task<Result<IEnumerable<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<User>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<int>> InsertAsync(User entity)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == entity.Name, cancellationToken.CancellationToken);
            if (user != null)
            {
                return Result<int>.Failure(UserBehavior.UserNameAlreadyExists);
            }

            if (user != null && user.Email == entity.Email)
            {
                return Result<int>.Failure(UserBehavior.UserEmailAlreadyExists);
            }
            await _dbContext.Users.AddAsync(entity, cancellationToken.CancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken.CancellationToken);

            return Result<int>.Success(entity.Id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
