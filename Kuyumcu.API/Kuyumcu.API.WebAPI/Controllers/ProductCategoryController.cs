using Kuyumcu.API.Application.Features.ProductCategories.CreateProductCategory;
using Kuyumcu.API.Application.Features.ProductCategories.DeleteProductCategory;
using Kuyumcu.API.Application.Features.ProductCategories.GetAllProductCategoryByBranchId;
using Kuyumcu.API.Application.Features.ProductCategories.GetProductCategoryById;
using Kuyumcu.API.Application.Features.ProductCategories.UpdateProductCategory;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Controllers
{
    public sealed class ProductCategoryController : ApiController
    {
        public ProductCategoryController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranchId(CancellationToken cancellationToken)
        {
            Guid? branchId = _helper?.GetBranchId();
            GetAllProductCategoryByBranchIdQuery command = new()
            {
                BranchId = branchId ?? Guid.Empty
            };
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetAllBranchId(Guid Id,CancellationToken cancellationToken)
        {
            GetProductCategoryByIdQuery command = new(Id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            request.BranchId = _helper?.GetBranchId() ?? Guid.Empty;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
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
