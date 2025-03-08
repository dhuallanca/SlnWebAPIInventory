using Domain.ResultHandler;
using MediatR;


namespace Application.Features.Entreprise.Commands
{
    public record CreateSubsidiaryCommand(string Name, string Address): IRequest<Result<SubsidiaryDto>>;
}
