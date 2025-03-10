using Domain.Entities.Entreprise;
using Domain.Interfaces;
using Domain.Interfaces.Entrreprise;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.Entreprise
{
    public class SubsidiaryRepository(InventoryDBContext dbContext, ICancellationTokenService cancellationToken) : RepositoryBase<Subsidiary>(dbContext, cancellationToken), ISubsidiaryRepository
    {
        public async Task<bool> NameExistsAsync(string name)
        {
            var subsidiary = await dbContext.Subsidiaries.FirstOrDefaultAsync(s => s.Name.Equals(name) && s.IsActive);

            if (subsidiary != null) {
                return true;
            }
            return false;
        }
    }
}
