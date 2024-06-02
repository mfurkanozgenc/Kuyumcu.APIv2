using AutoMapper;
using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.CreateProduct
{
    public sealed class CreateProductCommandHandler(
        IProductRepository productRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Boolean isNameExsist = await productRepository.AnyAsync(p => p.Name.Equals(request.Name) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted);

            if (isNameExsist)
            {
                return Result<Guid>.Failure("Bu Şubede Daha Önce Aynı İsimle Ürün Oluşturulmuştur");
            }

            Boolean isCodeExsist = await productRepository.AnyAsync(p => p.Code.Equals(request.Code) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted);

            if (isCodeExsist)
            {
                return Result<Guid>.Failure("Bu Şubede Daha Önce Aynı Kodla Ürün Oluşturulmuştur");
            }

            if (!string.IsNullOrEmpty(request.Barcode))
            {
                Boolean isBracodeExsist = await productRepository.AnyAsync(p => p.Barcode.Equals(request.Barcode) && p.BranchId.Equals(request.BranchId) && !p.IsDeleted);

                if (isBracodeExsist)
                {
                    return Result<Guid>.Failure("Bu Şubede Daha Önce Aynı Barkodla Ürün Oluşturulmuştur");
                }
            }

            Product product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
