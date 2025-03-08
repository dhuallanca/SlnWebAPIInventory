using Infrastructure.Interfaces;
using System.Security.Claims;

namespace WebInventory.Utilities
{
    public class UserIdProvider(IHttpContextAccessor contextAccessor) : IUserIdProvider
    {
        public string UserId
        {
            get
            {
                var identity = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
                return identity ?? "not user";
            }
        }
    }
}
