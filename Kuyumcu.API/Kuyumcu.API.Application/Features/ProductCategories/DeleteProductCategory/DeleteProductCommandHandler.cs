﻿using GenericRepository;
using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Repositories;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.DeleteProductCategory
{
    public sealed class DeleteProductCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            ProductCategory productCategory = await productCategoryRepository.GetByExpressionWithTrackingAsync(pc => pc.Id.Equals(request.Id), cancellationToken);

            if (productCategory is null)
            {
                return Result<string>.Failure("Ürün Kategorisi Bulunamadı");
            }

            productCategory.IsDeleted = true;
            productCategory.DeletedDate = DateTime.Now;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Kategori Silme Başarılı";
        }
    }
}
