using Domain.Interfaces;

namespace WebInventory.Utilities
{
    public class CurrentCancellationTokenService(IHttpContextAccessor httpContextAccessor) : ICancellationTokenService
    {
        public CancellationToken CancellationToken => httpContextAccessor.HttpContext!.RequestAborted;
    }
}
