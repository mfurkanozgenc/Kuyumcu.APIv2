
using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.GetProductById
{
    public sealed record GetProductByIdQuery (Guid Id) : IRequest<Result<Product>>;
}
