using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Enums;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.StockMovements.CreateStockMovement
{
    public sealed class CreateStockMovementCommandHandler(
        IStockMovementRepository stockMovementRepository,
        IProductRepository productRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateStockMovementCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
        {
            StokMovement stokMovement = mapper.Map<StokMovement>(request);

            await stockMovementRepository.AddAsync(stokMovement, cancellationToken);

            var product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id == stokMovement.ProductId, cancellationToken);
            if (product is not null)
            {
                decimal newStock = product.Stock - request.Quantity;
                if (stokMovement.Type == StockMovementTypeEnum.ProductRelease && newStock < 0)
                {
                    newStock *= -1;
                    return Result<Guid>.Failure($"Bu Ürün İçin {newStock} Adet Eksik Stok Vardır.İşlem Yapılamaz");
                }

                await unitOfWork.SaveChangesAsync(cancellationToken);

                List<StokMovement> stokMovements = await stockMovementRepository.Where(s => s.ProductId == request.ProductId && !s.IsDeleted).ToListAsync();
                decimal entryStock = stokMovements.Where(s => s.Type == StockMovementTypeEnum.ProductEntry).Sum(s => s.Quantity);
                decimal releaseStock = stokMovements.Where(s => s.Type == StockMovementTypeEnum.ProductRelease).Sum(s => s.Quantity);

                decimal generalStock = entryStock - releaseStock;

                product.IsStockStatus = generalStock <= 0 ? false : true;

                decimal totalCost = 0;
                decimal totalQuantity = 0;
                var entryMovements = stokMovements.Where(s => s.Type == StockMovementTypeEnum.ProductEntry);
                foreach (var movement in entryMovements)
                {
                    totalCost += movement.Quantity * movement.Price;
                    totalQuantity += movement.Quantity;
                }

                decimal averagePrice = totalQuantity != 0 ? Math.Ceiling(totalCost / totalQuantity) : 0;
                product.Stock = generalStock;
                product.Price = averagePrice;
            }
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return stokMovement.Id;
        }
    }
}
