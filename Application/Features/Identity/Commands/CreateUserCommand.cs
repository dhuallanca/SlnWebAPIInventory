using Domain.ResultHandler;
using MediatR;


namespace Application.Features.Identity.Commands
{
    public record CreateUserCommand(string Name, string Password, string Email, string FirstName, string LastName) : IRequest<Result<UserDto>>;
}
