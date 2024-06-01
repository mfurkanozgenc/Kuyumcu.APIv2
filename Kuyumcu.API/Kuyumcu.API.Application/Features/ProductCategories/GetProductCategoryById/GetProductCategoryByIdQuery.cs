using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.GetProductCategoryById
{
    public sealed record GetProductCategoryByIdQuery(Guid ProductCategoryId) : IRequest<Result<ProductCategory>>;
}
