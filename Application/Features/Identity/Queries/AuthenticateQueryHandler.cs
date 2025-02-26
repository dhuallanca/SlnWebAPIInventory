using Domain.Entities.Identity;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Features.Identity.Queries
{
    public class AuthenticateQueryHandler(IUserRepository userRepository, IConfiguration configuration) : IRequestHandler<AuthenticateQuery, Result<AuthenticateDto>>
    {
        // minutes
        const int expirationTime = 30;
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
            var token = GenerateJwtoken(user);
            var authenticate = new AuthenticateDto(user.Id, user.Name, user.Email, token, expirationTime);

            return Result<AuthenticateDto>.Success(authenticate);
        }

        static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            const int keySize = 64;
            var saltBytes = Convert.FromHexString(salt);
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, iterations: 10000, HashAlgorithmName.SHA256, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword));
        }

        string GenerateJwtoken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:SecretKey"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.UserData, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Jwt:Issuer"],
                audience: configuration["Authentication:Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(expirationTime),
                signingCredentials: credential);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
