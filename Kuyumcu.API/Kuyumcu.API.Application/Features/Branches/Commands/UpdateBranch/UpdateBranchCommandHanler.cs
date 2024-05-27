using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.UpdateBranch
{
    public sealed class UpdateBranchCommandHanler(
        IBranchRepository branchRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch branch = await branchRepository.GetByExpressionWithTrackingAsync(b => b.Id == request.Id && !b.IsDeleted);
            if (branch is null)
            {
                return Result<string>.Failure("Şube Bulunamadı");
            }

            Branch? exsistNameControl = await branchRepository.GetByExpressionAsync
                (b => b.Name == request.Name
                && b.Id != request.Id
                && b.CompanyId.Equals(branch.CompanyId)
                && !b.IsDeleted);

            if (exsistNameControl is not null)
            {
                return Result<string>.Failure("Aynı İsimle Daha Önce Şube Oluşurulmuştur");
            }

            mapper.Map(request,branch);
            branch.UpdatedDate = DateTime.Now;
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Şube Güncelleme Başarılı";

        }
    }
}
