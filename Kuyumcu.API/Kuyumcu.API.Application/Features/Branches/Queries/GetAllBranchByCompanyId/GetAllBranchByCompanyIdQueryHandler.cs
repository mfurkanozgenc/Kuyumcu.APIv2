using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Queries.GetAllBranchByCompanyId
{
    public sealed class GetAllBranchByCompanyIdQueryHandler(
        IBranchRepository branchRepository) : IRequestHandler<GetAllBranchByCompanyIdQuery, Result<List<Branch>>>
    {
        public async Task<Result<List<Branch>>> Handle(GetAllBranchByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            List<Branch> branches = await branchRepository
                .Where(b => b.CompanyId.Equals(request.CompanyId) && !b.IsDeleted)
                .ToListAsync(cancellationToken);

            return branches;
        }
    }
}
