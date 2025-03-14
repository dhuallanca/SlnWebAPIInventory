﻿using Domain.Entities.Identity;
using Domain.Interfaces;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Repository.Identity
{
    public class UserRepository(InventoryDBContext _dbContext, ICancellationTokenService cancellationToken) : RepositoryBase<User>(_dbContext, cancellationToken), IUserRepository
    {
        public async Task<Result<User>> Authenticate(string userName, string password)
        {
            var user = await _dbContext.Users.Include(u => u.UserRoles).Include(u => u.Roles).FirstOrDefaultAsync(u => u.Name == userName &&  u.IsActive == true, cancellationToken.CancellationToken);
            if (user == null) {
                return Result<User>.Failure(UserBehavior.UserInvalid);
            }
            
            return Result<User>.Success(user);
        }
       

        public async Task<Result<int>> InsertAsync(User entity)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == entity.Name && u.IsActive == true, cancellationToken.CancellationToken);
            if (user != null)
            {
                return Result<int>.Failure(UserBehavior.UserNameAlreadyExists);
            }

            if (user != null && user.Email == entity.Email)
            {
                return Result<int>.Failure(UserBehavior.UserEmailAlreadyExists);
            }
            entity.IsActive = true;
            await base.InsertAsync(entity);
            //await _dbContext.Users.AddAsync(entity, cancellationToken.CancellationToken);
            //await _dbContext.SaveChangesAsync(cancellationToken.CancellationToken);

            return Result<int>.Success(entity.Id);
        }

    }
}
