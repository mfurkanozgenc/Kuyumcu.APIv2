using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.CreateProductType
{
    public sealed class CreateProductTypeCommand : IRequest<Result<Guid>>
    {
        public Guid BranchId;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
