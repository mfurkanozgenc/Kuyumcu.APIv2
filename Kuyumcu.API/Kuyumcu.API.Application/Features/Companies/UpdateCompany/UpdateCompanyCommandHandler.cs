using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.UpdateCompany
{
    public sealed class UpdateCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateCompanyCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await companyRepository.GetByExpressionWithTrackingAsync(c => c.Id == request.Id && !c.IsDeleted, cancellationToken);

            if (company is null)
            {
                return Result<string>.Failure("İşletme Bulunamadı");
            }

            mapper.Map(request, company);
            company.UpdatedDate = DateTime.Now;

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "İşletme Güncelleme Başarılı";
        }
    }
}
