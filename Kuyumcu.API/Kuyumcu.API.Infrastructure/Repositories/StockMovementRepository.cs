using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using Kuyumcu.API.Infrastructure.Context;

namespace Kuyumcu.API.Infrastructure.Repositories
{
    internal sealed class StockMovementRepository : Repository<StokMovement, ApplicationDbContext>, IStockMovementRepository
    {
        public StockMovementRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
