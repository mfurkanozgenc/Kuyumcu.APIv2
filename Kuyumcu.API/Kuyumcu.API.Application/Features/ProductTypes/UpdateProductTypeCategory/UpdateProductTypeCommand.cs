using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductTypes.UpdateProductTypeCategory
{
    public sealed class UpdateProductTypeCommand : IRequest<Result<string>>
    {
        public Guid BranchId;
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
