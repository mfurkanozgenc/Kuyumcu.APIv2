using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.DeleteBranchById
{
    public sealed class DeleteBranchByIdCommandHandler(
        IBranchRepository branchRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteBranchByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBranchByIdCommand request, CancellationToken cancellationToken)
        {
            Branch branch = await branchRepository.GetByExpressionWithTrackingAsync(b => b.Id == request.Id && !b.IsDeleted);
            if (branch is null)
            {
                return Result<string>.Failure("Şube Bulunamadı");
            }

            branch.IsDeleted = true;
            branch.DeletedDate = DateTime.Now;

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Şube Silme Başarılı";
        }
    }
}
