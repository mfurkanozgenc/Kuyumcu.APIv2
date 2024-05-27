using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.DeleteCompany
{
    public sealed class DeleteCompanyByIdCommandHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompanyByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            Company? company = await companyRepository.GetByExpressionWithTrackingAsync(c => c.Id == request.Id && !c.IsDeleted);
            
            if(company is null)
            {
                return Result<string>.Failure("İşletme Bulunamadı");
            }

            company.IsDeleted = true;
            company.DeletedDate = DateTime.Now;
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "İşletme Silme Başarılı";
        }
    }
}
 