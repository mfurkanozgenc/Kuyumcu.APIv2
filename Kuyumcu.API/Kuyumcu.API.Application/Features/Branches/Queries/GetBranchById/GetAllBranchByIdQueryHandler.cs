using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Queries.GetBranchById
{
    public sealed class GetAllBranchByIdQueryHandler(
        IBranchRepository branchRepository) : IRequestHandler<GetAllBranchByIdQuery, Result<Branch>>
    {
        public async Task<Result<Branch>> Handle(GetAllBranchByIdQuery request, CancellationToken cancellationToken)
        {
            Branch? branch = await branchRepository
                .GetByExpressionAsync(b => b.Id.Equals(request.Id) && !b.IsDeleted);

            if (branch is null)
            {
                return Result<Branch>.Failure("Şube Bulunamadı");
            }

            return branch;
        }
    }
}
