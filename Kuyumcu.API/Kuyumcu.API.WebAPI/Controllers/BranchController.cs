using Kuyumcu.API.Application.Features.Branches.Commands.CreateBranch;
using Kuyumcu.API.Application.Features.Branches.Commands.DeleteBranchById;
using Kuyumcu.API.Application.Features.Branches.Commands.UpdateBranch;
using Kuyumcu.API.Application.Features.Branches.Queries.GetAllBranchByCompanyId;
using Kuyumcu.API.Application.Features.Branches.Queries.GetBranchById;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kuyumcu.API.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class BranchController : ApiController
    {
        public BranchController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetByCompanyId(Guid companyId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllBranchByCompanyIdQuery(companyId), cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{branchId}")]
        public async Task<IActionResult> GetById([Required] Guid branchId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllBranchByIdQuery(branchId), cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{branchId}")]
        public async Task<IActionResult> DeleteById(Guid branchId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteBranchByIdCommand(branchId), cancellationToken);;
            return StatusCode(response.StatusCode, response);
        }
    }
}
