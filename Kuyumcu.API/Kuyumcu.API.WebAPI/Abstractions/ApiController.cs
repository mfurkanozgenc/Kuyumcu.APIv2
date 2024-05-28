using Kuyumcu.API.Application.Helper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kuyumcu.API.WebAPI.Abstractions
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly Helper? _helper;

        // İlk constructor, her iki bağımlılığı da ayarlar
        protected ApiController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _helper = new Helper(httpContextAccessor);
        }

        // İkinci constructor sadece IMediator'ı ayarlar
        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
            _helper = null; // _helper'ı null olarak ayarlar
        }
    }
}
