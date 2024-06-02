using Kuyumcu.API.Domain.Abstractions;
using Kuyumcu.API.Domain.Enums;

namespace Kuyumcu.API.Domain.Entities
{
    public sealed class StokMovement : BranchEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public StockMovementTypeEnum Type { get; set; } = StockMovementTypeEnum.ProductEntry;
    }
}
