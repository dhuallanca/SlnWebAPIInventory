using Domain.ResultHandler;


namespace Domain.Entities.Entreprise
{
    public static class SubsidiaryBehavior
    {
        public static readonly Error SubsidiaryExists = new("Subsidiary name already Exists", ErrorHttpStatus.BadRequest);
    }
}
