using Domain.Entities.Entreprise;
using Domain.Interfaces.Entrreprise;
using Domain.ResultHandler;
using MediatR;


namespace Application.Features.Entreprise.Queries
{
    public class GetListSubsidiaryQueryHandler(ISubsidiaryRepository subsidiaryRepository) : IRequestHandler<GetListSubsidiaryQuery, Result<IEnumerable<SubsidiaryDto>>>
    {
        public async Task<Result<IEnumerable<SubsidiaryDto>>> Handle(GetListSubsidiaryQuery request, CancellationToken cancellationToken)
        {
            var listSubsidiary = await subsidiaryRepository.GetAllAsync(x=> x.IsActive == request.IsActive);
            var subsidiaries = MappingFunctions<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryDto>>.MapModelToDto(listSubsidiary.Model);
            return Result<IEnumerable<SubsidiaryDto>>.Success(subsidiaries);
        }
    }

}
