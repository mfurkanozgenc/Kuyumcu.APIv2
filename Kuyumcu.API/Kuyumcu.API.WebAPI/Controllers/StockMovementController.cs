using Kuyumcu.API.Application.Features.Products.CreateProduct;
using Kuyumcu.API.Application.Features.Products.DeleteProduct;
using Kuyumcu.API.Application.Features.Products.GetAllProductByBranchId;
using Kuyumcu.API.Application.Features.Products.GetProductById;
using Kuyumcu.API.Application.Features.Products.UpdateProduct;
using Kuyumcu.API.Application.Features.StockMovements.CreateStockMovement;
using Kuyumcu.API.Application.Features.StockMovements.DeleteStockMovement;
using Kuyumcu.API.Application.Features.StockMovements.GetAllStockMovementByProductId;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Controllers
{
    public sealed class StockMovementController : ApiController
    {
        public StockMovementController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet("ProductId")]
        public async Task<IActionResult> GetByProductId(Guid ProductId, CancellationToken cancellationToken)
        {
            GetAllStockMovementByProductIdQuery command = new(ProductId);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockMovementCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteStockMovementCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
