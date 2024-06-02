using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.GetAllProductByBranchId
{
    public sealed class GetAllProductByBranchIdQuery : IRequest<Result<List<Product>>>
    {
        public Guid BranchId;
    }
}
