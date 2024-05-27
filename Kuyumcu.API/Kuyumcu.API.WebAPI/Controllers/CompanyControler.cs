using Kuyumcu.API.Application.Features.Companies.CreateCompany;
using Kuyumcu.API.Application.Features.Companies.DeleteCompany;
using Kuyumcu.API.Application.Features.Companies.GetAllCompany;
using Kuyumcu.API.Application.Features.Companies.UpdateCompany;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kuyumcu.API.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class CompanyController : ApiController
    {
        public CompanyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("CompanyId")]
        public async Task<IActionResult> GetById([Required] Guid CompanyId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCompanyByIdQuery(CompanyId), cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(DeleteCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
