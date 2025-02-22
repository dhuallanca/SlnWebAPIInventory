using Infrastructure.Interfaces;

namespace WebInventory.Utilities
{
    public class UserIdProvider(IHttpContextAccessor contextAccessor) : IUserIdProvider
    {
        public int UserId => (int)(contextAccessor.HttpContext?.Items["userid"] ?? 0);
    }
}
