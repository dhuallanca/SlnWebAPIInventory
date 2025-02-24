using Domain.Entities.Identity;
using Domain.Interfaces.Identity;
using Domain.ResultHandler;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Queries
{
    public class AuthenticateQueryHandler(IUserRepository userRepository) : IRequestHandler<AuthenticateQuery, Result<AuthenticateDto>>
    {
        public async Task<Result<AuthenticateDto>> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.Authenticate(request.UserName, request.Password);
            if (result.IsFailure) {
                return Result<AuthenticateDto>.Failure(result.Error);
            }
            var user = result.Model;
            var authenticate = new AuthenticateDto(user.Id, user.Name, "token", 30);

            return Result<AuthenticateDto>.Success(authenticate);
        }
    }
}
