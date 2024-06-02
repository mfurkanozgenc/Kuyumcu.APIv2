
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.GetProductById
{
    public sealed class GetProductByIdQueryHandler(
        IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Result<Product>>
    {
        public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id.Equals(request.Id) && !p.IsDeleted, cancellationToken);

            if (product is null)
            {
                return Result<Product>.Failure("Ürün Bulunamadı");
            }
            return product;
        }
    }
}
