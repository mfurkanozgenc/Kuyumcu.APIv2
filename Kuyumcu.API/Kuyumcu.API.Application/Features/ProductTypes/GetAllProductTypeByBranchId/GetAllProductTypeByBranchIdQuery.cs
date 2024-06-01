using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.GetAllProductTypeByBranchId
{
    public sealed class GetAllProductTypeByBranchIdQuery : IRequest<Result<List<ProductType>>>
    {
        public Guid BranchId;
    }
}
