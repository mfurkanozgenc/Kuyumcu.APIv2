using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.DeleteProductType
{
    public sealed class DeleteProductTypeCommandHandler(
        IProductTypeRepository productTypeRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductTypeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            ProductType productType = await productTypeRepository.GetByExpressionWithTrackingAsync(pc => pc.Id.Equals(request.Id), cancellationToken);

            if (productType is null)
            {
                return Result<string>.Failure("Ürün Tipi Bulunamadı");
            }

            productType.IsDeleted = true;
            productType.DeletedDate = DateTime.Now;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Tipi Silme Başarılı";
        }
    }
}
