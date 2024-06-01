using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.CreateProductType
{
    public sealed class CreateProductTypeCommandHandler(
        IProductTypeRepository producTypeRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateProductTypeCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var nameControl = await producTypeRepository
                .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
                pc.Name.Equals(request.Name));

            if (nameControl)
            {
                return Result<Guid>.Failure("Bu Şubede Aynı İsimle Ürün Tipi Kaydedilmiştir");
            }

            var codeControl = await producTypeRepository
               .AnyAsync(pc => pc.BranchId.Equals(request.BranchId) &&
               pc.Code.Equals(request.Code));

            if (codeControl)
            {
                return Result<Guid>.Failure("Bu Şubede Aynı Kodla Ürün Tipi Kaydedilmiştir");
            }
            
            ProductType productCategory = mapper.Map<ProductType>(request);
            await producTypeRepository.AddAsync(productCategory, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return productCategory.Id;
        }
    }
}
