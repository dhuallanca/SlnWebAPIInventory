using Domain.ResultHandler;

namespace Domain.Utilities
{
    public static class GeneralError
    {
        public static readonly Error DoesntExists = new("Does not exists", ErrorHttpStatus.BadRequest);
       
    }
}
