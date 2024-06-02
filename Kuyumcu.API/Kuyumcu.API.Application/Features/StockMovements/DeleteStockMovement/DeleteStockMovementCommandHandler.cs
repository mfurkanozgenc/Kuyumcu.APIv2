using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Enums;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Kuyumcu.API.Application.Features.StockMovements.DeleteStockMovement
{
    internal sealed class DeleteStockMovementCommandHandler(
        IStockMovementRepository stockMovementRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockMovementCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteStockMovementCommand request, CancellationToken cancellationToken)
        {
            StokMovement? stokMovement = await stockMovementRepository.GetByExpressionWithTrackingAsync(s => s.Id.Equals(request.Id) && !s.IsDeleted);

            if(stokMovement is null)
            {
                return Result<string>.Failure("Stok İşlemi Bulunamadı");
            }

            Product product = await productRepository.GetByExpressionWithTrackingAsync(s => s.Id.Equals(stokMovement.ProductId) && !s.IsDeleted);

            if(product is null)
            {
                return Result<string>.Failure("Stok İşlemine Ait Ürün Bulunamadı");
            }
            stokMovement.IsDeleted = true;
            stokMovement.DeletedDate = DateTime.Now;
            await unitOfWork.SaveChangesAsync(cancellationToken);

            List<StokMovement> stokMovements = await stockMovementRepository.Where(s => s.ProductId == product.Id && !s.IsDeleted).ToListAsync();
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
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Stok Silme İşlemi Başarılı";
        }
    }
}
   