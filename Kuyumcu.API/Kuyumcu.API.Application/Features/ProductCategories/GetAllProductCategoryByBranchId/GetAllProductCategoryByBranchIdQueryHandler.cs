using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.GetAllProductCategoryByBranchId
{
    internal sealed class GetAllProductCategoryByBranchIdQueryHandler(
        IProductCategoryRepository productCategoryRepository) : IRequestHandler<GetAllProductCategoryByBranchIdQuery, Result<List<ProductCategory>>>
    {
        public async Task<Result<List<ProductCategory>>> Handle(GetAllProductCategoryByBranchIdQuery request, CancellationToken cancellationToken)
        {
            List<ProductCategory> productCategories = await productCategoryRepository
                .Where(pc => pc.BranchId.Equals(request.BranchId))
                .ToListAsync();
            return productCategories;
        }
    }
}
