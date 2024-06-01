using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.GetProductTypeById
{
    public sealed class GetProductTypeByIdQueryHandler(
        IProductTypeRepository productTypeRepository) : IRequestHandler<GetProductTypeByIdQuery, Result<ProductType>>
    {
        public async Task<Result<ProductType>> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            ProductType? productType = await productTypeRepository
                .Where(pc => pc.Id.Equals(request.ProductTypeId))
                .Include(t => t.Products).FirstOrDefaultAsync();

            if (productType is null)
            {
                return Result<ProductType>.Failure("Ürün Kategorisi Bulunamadı");
            }

            return productType;
        }
    }
}
