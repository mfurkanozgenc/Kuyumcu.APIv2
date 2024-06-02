using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Products.CreateProduct
{
    public sealed class CreateProductCommand : IRequest<Result<Guid>>
    {
        public Guid BranchId;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid ProductTypeId { get; set; }
    }
}
