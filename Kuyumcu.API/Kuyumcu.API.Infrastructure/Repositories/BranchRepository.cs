using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using Kuyumcu.API.Infrastructure.Context;

namespace Kuyumcu.API.Infrastructure.Repositories
{
    internal sealed class BranchRepository : Repository<Branch, ApplicationDbContext>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
