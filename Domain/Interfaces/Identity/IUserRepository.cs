using Domain.Identity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Identity
{
    public class IUserRepository : IRepositoryBase<User>
    {
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
    }
}
