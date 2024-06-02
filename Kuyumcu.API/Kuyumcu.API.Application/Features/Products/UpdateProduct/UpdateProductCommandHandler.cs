using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id.Equals(request.Id) && !p.IsDeleted, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            if(product.Name != request.Name)
            {
                Boolean isNameExsist = await productRepository.AnyAsync(p => p.Name.Equals(request.Name) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted && p.Id != request.Id);

                if (isNameExsist)
                {
                    return Result<string>.Failure("Bu Şubede Daha Önce Aynı İsimle Ürün Oluşturulmuştur");
                }
            }

            if(product.Code != request.Code)
            {
                Boolean isCodeExsist = await productRepository.AnyAsync(p => p.Code.Equals(request.Code) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted && p.Id != request.Id);

                if (isCodeExsist)
                {
                    return Result<string>.Failure("Bu Şubede Daha Önce Aynı Kodla Ürün Oluşturulmuştur");
                }
            }

            if (!string.IsNullOrEmpty(request.Barcode) && product.Barcode != request.Barcode)
            {
                Boolean isBracodeExsist = await productRepository.AnyAsync(p => p.Barcode.Equals(request.Barcode) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted && p.Id != request.Id);

                if (isBracodeExsist)
                {
                    return Result<string>.Failure("Bu Şubede Daha Önce Aynı Barkodla Ürün Oluşturulmuştur");
                }
            }

            mapper.Map(request, product);
            product.UpdatedDate = DateTime.Now;
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Güncelleme Başarılı";
        }
    }
}
