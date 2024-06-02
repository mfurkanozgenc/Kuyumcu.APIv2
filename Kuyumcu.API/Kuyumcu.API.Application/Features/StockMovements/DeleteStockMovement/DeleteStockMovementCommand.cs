using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.StockMovements.DeleteStockMovement
{
    public sealed record DeleteStockMovementCommand(Guid Id) : IRequest<Result<string>>;
}
   