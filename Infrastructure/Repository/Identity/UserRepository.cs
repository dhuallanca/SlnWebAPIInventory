using Domain.Entities.Identity;
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
    public class UserRepository(InventoryDBContext _dbContext) : IUserRepository, IDisposable
    {
        public async Task<Result<User>> Authenticate(string userName, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == userName &&  u.Password == password);
            if (user == null) {
                return Result<User>.Failure(UserBehavior.UserInvalid);
            }
            return Result<User>.Success(user);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertById(User entity)
        {
            throw new NotImplementedException();
        }

        public void InsertByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateByIdAsync(User entity)
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
