using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using Kuyumcu.API.Infrastructure.Context;

namespace Kuyumcu.API.Infrastructure.Repositories
{
    internal sealed class ProductCategoryRepository : Repository<ProductCategory, ApplicationDbContext>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
