using Kuyumcu.API.Application.Features.Products.CreateProduct;
using Kuyumcu.API.Application.Features.Products.DeleteProduct;
using Kuyumcu.API.Application.Features.Products.GetAllProductByBranchId;
using Kuyumcu.API.Application.Features.Products.GetProductById;
using Kuyumcu.API.Application.Features.Products.UpdateProduct;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Controllers
{
    public sealed class ProductController : ApiController
    {
        public ProductController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranchId(CancellationToken cancellationToken)
        {
            Guid? branchId = _helper?.GetBranchId();
            GetAllProductByBranchIdQuery command = new()
            {
                BranchId = branchId ?? Guid.Empty
            };
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
        {
            GetProductByIdQuery command = new(Id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
