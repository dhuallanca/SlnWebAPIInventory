using Domain.Entities.Entreprise;


namespace Domain.Interfaces.Entrreprise
{
    public interface ISubsidiaryRepository : IRepositoryBase<Subsidiary>
    {
        Task<bool> NameExistsAsync(string name);
    }
}
