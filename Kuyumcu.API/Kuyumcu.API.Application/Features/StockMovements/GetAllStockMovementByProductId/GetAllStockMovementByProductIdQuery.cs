using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.StockMovements.GetAllStockMovementByProductId
{
    public sealed record GetAllStockMovementByProductIdQuery(Guid Id) : IRequest<Result<List<StokMovement>>>;

    internal sealed class GetAllStockMovementByProductIdQueryHandler(
        IStockMovementRepository stockMovementRepository) : IRequestHandler<GetAllStockMovementByProductIdQuery, Result<List<StokMovement>>>
    {
        public async Task<Result<List<StokMovement>>> Handle(GetAllStockMovementByProductIdQuery request, CancellationToken cancellationToken)
        {
            List<StokMovement> stokMovements = await stockMovementRepository.Where(s => s.ProductId.Equals(request.Id)).ToListAsync();
            return stokMovements;
        }
    }
}
