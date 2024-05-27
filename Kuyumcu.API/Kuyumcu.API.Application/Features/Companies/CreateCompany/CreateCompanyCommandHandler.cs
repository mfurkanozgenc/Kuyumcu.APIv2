using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.CreateCompany
{
    public sealed class CreateCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateCompanyCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = mapper.Map<Company>(request);

            await companyRepository.AddAsync(company,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}
