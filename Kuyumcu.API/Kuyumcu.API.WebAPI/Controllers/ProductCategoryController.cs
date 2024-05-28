using Kuyumcu.API.Application.Features.Auth.Login;
using Kuyumcu.API.Application.Helper;
using Kuyumcu.API.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Controllers
{
    public sealed class ProductCategoryController : ApiController
    {
        public ProductCategoryController(IMediator mediator , IHttpContextAccessor httpContextAccessor) : base(mediator,httpContextAccessor)
        {
        }

        [HttpPost]
        public IActionResult GetBranchId(LoginCommand request, CancellationToken cancellationToken)
        {
            var branchId = _helper?.GetBranchId();
            return StatusCode(200, branchId);
        }
    }
}
