using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.UpdateProductTypeCategory
{
    public sealed class UpdateProductTypeCommandHandler(
        IProductTypeRepository productTypeRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductTypeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            ProductType productCategory = await productTypeRepository.GetByExpressionWithTrackingAsync(pc => pc.Id.Equals(request.Id), cancellationToken);

            if (productCategory is null)
            {
                return Result<string>.Failure("Ürün Tipi Bulunamadı");
            }

            if (request.Name != productCategory.Name)
            {
                var nameControl = await productTypeRepository
                    .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                    pc.Name.Equals(request.Name));

                if (nameControl)
                {
                    return Result<string>.Failure("Bu Şubede Aynı İsimle Ürün Tipi Kaydedilmiştir");
                }
            }

            if (request.Code != productCategory.Code)
            {
                var codeControl = await productTypeRepository
                   .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                   pc.Code.Equals(request.Code));

                if (codeControl)
                {
                    return Result<string>.Failure("Bu Şubede Aynı Kodla Ürün Tipi Kaydedilmiştir");
                }
            }

            mapper.Map(request, productCategory);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Tipi Güncelleme Başarılı";
        }
    }
}
