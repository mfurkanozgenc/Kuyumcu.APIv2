using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.GetAllProductCategoryByBranchId
{
    public sealed class GetAllProductCategoryByBranchIdQuery : IRequest<Result<List<ProductCategory>>>
    {
        public Guid BranchId;
    }
}
