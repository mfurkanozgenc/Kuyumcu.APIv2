using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using Kuyumcu.API.Infrastructure.Context;

namespace Kuyumcu.API.Infrastructure.Repositories
{
    internal sealed class CompanyRepository : Repository<Company, ApplicationDbContext>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
