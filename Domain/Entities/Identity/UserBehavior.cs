using Domain.ResultHandler;

namespace Domain.Entities.Identity
{
    public static class UserBehavior
    {
        public static readonly Error UserInvalid = new("User or Password invalid", ErrorHttpStatus.BadRequest);
    }
}
