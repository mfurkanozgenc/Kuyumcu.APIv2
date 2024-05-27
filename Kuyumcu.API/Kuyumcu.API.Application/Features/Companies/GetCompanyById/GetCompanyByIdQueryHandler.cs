using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.GetAllCompany
{
    public sealed class GetCompanyByIdQueryHandler(
        ICompanyRepository companyRepository) : IRequestHandler<GetCompanyByIdQuery, Result<Company>>
    {
        public async Task<Result<Company>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            Company? company = await companyRepository
                .Where(c => c.Id == request.Id && !c.IsDeleted)
                .Include(c => c.Branches)
                .FirstOrDefaultAsync(cancellationToken);

            if(company is null)
            {
                return Result<Company>.Failure("İşletme Bulunamadı");
            }

            return company;
        }
    }
}
