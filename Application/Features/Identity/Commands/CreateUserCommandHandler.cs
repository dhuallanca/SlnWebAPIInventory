using Application.Features.Identity.Queries;
using Domain.Entities.Identity;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Commands
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.Adapt<User>();
            var hashedPassword = HashPasword(request.Password, out var salt);
            user.Salt = salt;
            user.Password = hashedPassword;
            var result = await userRepository.InsertAsync(user);
            if (result.IsFailure)
            {
                return Result<UserDto>.Failure(result.Error);
            }
   
            var userDto = MappingFunctions<User, UserDto>.MapModelToDto(user);
            return Result<UserDto>.Success(userDto);
        }

        static string HashPasword(string password, out string salt)
        {
            const int keySize = 64;
            var randomSalt = RandomNumberGenerator.GetBytes(keySize);
            salt = Convert.ToHexString(randomSalt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, randomSalt, iterations: 10000, HashAlgorithmName.SHA256, keySize);
            return Convert.ToHexString(hash);
        }
    }
}
