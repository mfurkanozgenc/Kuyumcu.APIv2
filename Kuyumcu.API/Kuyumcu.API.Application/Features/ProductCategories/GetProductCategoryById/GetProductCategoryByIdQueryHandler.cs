using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.GetProductCategoryById
{
    public sealed class GetProductCategoryByIdQueryHandler(
        IProductCategoryRepository productCategoryRepository) : IRequestHandler<GetProductCategoryByIdQuery, Result<ProductCategory>>
    {
        public async Task<Result<ProductCategory>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await productCategoryRepository
                .Where(pc => pc.Id.Equals(request.ProductCategoryId))
                .Include(t => t.Products).FirstOrDefaultAsync();

            if(productCategory is null)
            {
                return Result<ProductCategory>.Failure("Ürün Kategorisi Bulunamadı");
            }

            return productCategory;
        }
    }
}
