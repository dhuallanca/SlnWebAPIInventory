
namespace Application.Features.Identity
{
    public record AuthenticateDto(int Id, string Name, string Token, int ExpirationTime);
}
