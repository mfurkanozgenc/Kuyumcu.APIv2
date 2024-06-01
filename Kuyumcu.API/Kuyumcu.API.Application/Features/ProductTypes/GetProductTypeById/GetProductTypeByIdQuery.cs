using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.GetProductTypeById
{
    public sealed record GetProductTypeByIdQuery(Guid ProductTypeId) : IRequest<Result<ProductType>>;
}
