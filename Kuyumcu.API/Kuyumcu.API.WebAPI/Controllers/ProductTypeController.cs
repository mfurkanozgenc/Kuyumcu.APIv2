using Kuyumcu.API.Application.Features.ProductTypes.CreateProductType;
using Kuyumcu.API.Application.Features.ProductTypes.DeleteProductType;
using Kuyumcu.API.Application.Features.ProductTypes.GetAllProductTypeByBranchId;
using Kuyumcu.API.Application.Features.ProductTypes.GetProductTypeById;
using Kuyumcu.API.Application.Features.ProductTypes.UpdateProductTypeCategory;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Controllers
{
    public sealed class ProductTypeController : ApiController
    {
        public ProductTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranchId(CancellationToken cancellationToken)
        {
            Guid? branchId = _helper?.GetBranchId();
            GetAllProductTypeByBranchIdQuery command = new()
            {
                BranchId = branchId ?? Guid.Empty
            };
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid Id,CancellationToken cancellationToken)
        {
            GetProductTypeByIdQuery command = new(Id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
