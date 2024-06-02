using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.DeleteProduct
{
    public sealed class DeleteProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id.Equals(request.Id) && !p.IsDeleted, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            product.IsDeleted = true;
            product.DeletedDate = DateTime.Now;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Silme Başarıl";
        }
    }
}
