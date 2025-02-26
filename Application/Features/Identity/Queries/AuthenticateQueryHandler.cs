using Domain.Entities.Identity;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using MediatR;
using System.Security.Cryptography;

namespace Application.Features.Identity.Queries
{
    public class AuthenticateQueryHandler(IUserRepository userRepository) : IRequestHandler<AuthenticateQuery, Result<AuthenticateDto>>
    {
        public async Task<Result<AuthenticateDto>> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.Authenticate(request.UserName, request.Password);
            if (result.IsFailure)
            {
                return Result<AuthenticateDto>.Failure(result.Error);
            }

            var isAutehnticated = VerifyPassword(request.Password, result.Model?.Password, result.Model?.Salt);

            if (!isAutehnticated)
            {
                return Result<AuthenticateDto>.Failure(UserBehavior.UserInvalid);
            }
            var user = result.Model;
            var authenticate = new AuthenticateDto(user.Id, user.Name, "token", 30);

            return Result<AuthenticateDto>.Success(authenticate);
        }

        static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            const int keySize = 64;
            var saltBytes = Convert.FromHexString(salt);
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, iterations: 10000, HashAlgorithmName.SHA256, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword));
        }
    }
}
