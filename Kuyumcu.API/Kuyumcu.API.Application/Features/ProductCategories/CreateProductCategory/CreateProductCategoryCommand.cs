using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.CreateProductCategory
{
    public sealed class CreateProductCategoryCommand : IRequest<Result<Guid>>
    {
        public Guid BranchId;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
