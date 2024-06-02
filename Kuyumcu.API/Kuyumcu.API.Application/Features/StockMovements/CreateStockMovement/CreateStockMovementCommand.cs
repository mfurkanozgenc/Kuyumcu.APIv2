using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.StockMovements.CreateStockMovement
{
    public sealed class CreateStockMovementCommand : IRequest<Result<Guid>>
    {
        public Guid BranchId;
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int TypeValue { get; set; }
    }
}
