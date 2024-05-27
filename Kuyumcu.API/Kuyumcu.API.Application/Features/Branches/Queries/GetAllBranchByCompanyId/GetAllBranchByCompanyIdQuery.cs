using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Queries.GetAllBranchByCompanyId
{
    public sealed record GetAllBranchByCompanyIdQuery(Guid CompanyId) : IRequest<Result<List<Branch>>>;
}
