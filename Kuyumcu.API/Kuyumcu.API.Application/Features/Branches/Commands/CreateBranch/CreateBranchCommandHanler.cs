using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.CreateBranch
{
    public sealed class CreateBranchCommandHanler(
        IBranchRepository branchRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateBranchCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var exsistNameControl = await branchRepository.GetByExpressionAsync
                (b => b.Name == request.Name
                && b.CompanyId.Equals(request.CompanyId)
                && !b.IsDeleted);

            if (exsistNameControl is not null)
            {
                return Result<Guid>.Failure("Aynı İsimle Daha Önce Şube Oluşurulmuştur");
            }

            Branch branch = mapper.Map<Branch>(request);

            await branchRepository.AddAsync(branch,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return branch.Id;

        }
    }
}
