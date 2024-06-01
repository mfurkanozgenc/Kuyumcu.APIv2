using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.GetAllProductTypeByBranchId
{
    internal sealed class GetAllProductTypeByBranchIdQueryHandler(
        IProductTypeRepository productTypeRepository) : IRequestHandler<GetAllProductTypeByBranchIdQuery, Result<List<ProductType>>>
    {
        public async Task<Result<List<ProductType>>> Handle(GetAllProductTypeByBranchIdQuery request, CancellationToken cancellationToken)
        {
            List<ProductType> productTypes = await productTypeRepository
                .Where(pc => pc.BranchId.Equals(request.BranchId))
                .ToListAsync();
            return productTypes;
        }
    }
}
