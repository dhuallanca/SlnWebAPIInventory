using Domain.Entities.Identity;
using Domain.ResultHandler;

namespace Domain.Interfaces.Identity
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<Result<UserRole>> Authenticate(string userName, string password);
    }
}
