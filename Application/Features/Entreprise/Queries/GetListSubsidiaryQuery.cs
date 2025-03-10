using Domain.ResultHandler;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Entreprise.Queries
{
    public record GetListSubsidiaryQuery(bool IsActive) : IRequest<Result<IEnumerable<SubsidiaryDto>>>;

}
