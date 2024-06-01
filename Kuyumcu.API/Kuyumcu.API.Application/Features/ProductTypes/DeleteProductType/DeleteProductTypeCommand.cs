using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.DeleteProductType
{
    public sealed record DeleteProductTypeCommand (Guid Id) : IRequest<Result<string>>;
}
