
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.GetProductById
{
    public sealed class GetProductByIdQueryHandler(
        IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Result<Product>>
    {
        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? product = await productRepository
                .Where(p => p.Id.Equals(request.Id) && !p.IsDeleted)
                .Include(p => p.StokMovements)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null)
            {
                return Result<Product>.Failure("Ürün Bulunamadı");
            }

            foreach (var stockovement in product.StokMovements!)
            {
                stockovement.Product = null;
            }
            return product;
        }
    }
}
