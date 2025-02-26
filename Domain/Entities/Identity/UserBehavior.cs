using Domain.ResultHandler;

namespace Domain.Entities.Identity
{
    public static class UserBehavior
    {
        public static readonly Error UserInvalid = new("User or Password invalid", ErrorHttpStatus.BadRequest);
        public static readonly Error UserNotCreated = new("User not created", ErrorHttpStatus.BadRequest);
        public static readonly Error UserNameAlreadyExists = new("User name already exists", ErrorHttpStatus.BadRequest);
        public static readonly Error UserEmailAlreadyExists = new("User email already exist", ErrorHttpStatus.BadRequest);
    }
}
