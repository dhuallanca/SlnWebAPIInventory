
namespace Application.Features.Identity
{
    public record AuthenticateDto(int Id, string Name, string Email, string Token, int ExpirationTime, string Role);
}
