using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using Kuyumcu.API.Infrastructure.Context;

namespace Kuyumcu.API.Infrastructure.Repositories
{
    internal sealed class ProductTypeRepository : Repository<ProductType, ApplicationDbContext>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
