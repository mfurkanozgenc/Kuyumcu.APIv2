using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.DeleteProduct
{
    public sealed record DeleteProductCommand(Guid Id) : IRequest<Result<string>>;
}
