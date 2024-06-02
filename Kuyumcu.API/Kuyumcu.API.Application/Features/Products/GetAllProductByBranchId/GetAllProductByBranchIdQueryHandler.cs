using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.GetAllProductByBranchId
{
    public sealed class GetAllProductByBranchIdQueryHandler(
        IProductRepository productRepository) : IRequestHandler<GetAllProductByBranchIdQuery, Result<List<Product>>>
    {
        public async Task<Result<List<Product>>> Handle(GetAllProductByBranchIdQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await productRepository
                          .Where(p => p.BranchId.Equals(request.BranchId))
                          .ToListAsync();
            return products;
        }
    }
}
