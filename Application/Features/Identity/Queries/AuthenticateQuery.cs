using Domain.ResultHandler;
using MediatR;

namespace Application.Features.Identity.Queries
{
    // should return UserAuthentication
    public record AuthenticateQuery(string UserName, string Password) : IRequest<Result<AuthenticateDto>>;
}
