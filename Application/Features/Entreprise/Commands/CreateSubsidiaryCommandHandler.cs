using Application.Features.Identity;
using Domain.Entities.Entreprise;
using Domain.Entities.Identity;
using Domain.Interfaces.Entrreprise;
using Domain.ResultHandler;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Entreprise.Commands
{
    public class CreateSubsidiaryCommandHandler(ISubsidiaryRepository subsidiaryRepository) : IRequestHandler<CreateSubsidiaryCommand, Result<SubsidiaryDto>>
    {
        public async Task<Result<SubsidiaryDto>> Handle(CreateSubsidiaryCommand request, CancellationToken cancellationToken)
        {
            var subsidiary = request.Adapt<Subsidiary>();
            subsidiary.IsActive = true;
            var exists = await subsidiaryRepository.NameExistsAsync(subsidiary.Name);
            if (exists) {
                return Result<SubsidiaryDto>.Failure(SubsidiaryBehavior.SubsidiaryExists);
            }
            var result = await subsidiaryRepository.InsertAsync(subsidiary);
            if (result.IsFailure) {
                return Result<SubsidiaryDto>.Failure(result.Error);
            }

            var subsidiaryDto = MappingFunctions<Subsidiary, SubsidiaryDto>.MapModelToDto(subsidiary);
            return Result<SubsidiaryDto>.Success(subsidiaryDto);
        }
    }
}
