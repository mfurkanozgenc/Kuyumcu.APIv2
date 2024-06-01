using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.UpdateProductCategory
{
    public sealed class UpdateProductCategoryCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCategoryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory productCategory = await productCategoryRepository.GetByExpressionWithTrackingAsync(pc => pc.Id.Equals(request.Id),cancellationToken);

            if(productCategory is null)
            {
                return Result<string>.Failure("Ürün Kategorisi Bulunamadı");
            }

            if (request.Name != productCategory.Name)
            {
                var nameControl = await productCategoryRepository
                    .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                    pc.Name.Equals(request.Name));

                if (nameControl)
                {
                    return Result<string>.Failure("Bu Şubede Aynı İsimle Ürün Kategorisi Kaydedilmiştir");
                }
            }

            if (request.Code != productCategory.Code)
            {
                var codeControl = await productCategoryRepository
                   .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                   pc.Code.Equals(request.Code));

                if (codeControl)
                {
                    return Result<string>.Failure("Bu Şubede Aynı Kodla Ürün Kategorisi Kaydedilmiştir");
                }
            }

            mapper.Map(request, productCategory);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Kategori Güncelleme Başarılı";

        }
    }
}
