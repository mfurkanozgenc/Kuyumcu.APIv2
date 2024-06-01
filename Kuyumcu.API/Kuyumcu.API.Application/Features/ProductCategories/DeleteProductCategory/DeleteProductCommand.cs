using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.DeleteProductCategory
{
    public sealed record DeleteProductCommand (Guid Id) : IRequest<Result<string>>;
}
