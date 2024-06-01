using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.CreateProductCategory
{
    public sealed class CreateProductCategoryCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCategoryCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var nameControl = await productCategoryRepository
                .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                pc.Name.Equals(request.Name));

            if (nameControl)
            {
                return Result<Guid>.Failure("Bu Şubede Aynı İsimle Ürün Kategorisi Kaydedilmiştir");
            }

            var codeControl = await productCategoryRepository
               .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
               pc.Code.Equals(request.Code));

            if (codeControl)
            {
                return Result<Guid>.Failure("Bu Şubede Aynı Kodla Ürün Kategorisi Kaydedilmiştir");
            }
            
            ProductCategory productCategory = mapper.Map<ProductCategory>(request);
            await productCategoryRepository.AddAsync(productCategory, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return productCategory.Id;
        }
    }
}
