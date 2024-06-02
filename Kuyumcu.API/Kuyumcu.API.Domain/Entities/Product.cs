using Kuyumcu.API.Domain.Abstractions;

namespace Kuyumcu.API.Domain.Entities
{
    public sealed class Product : BranchEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public bool IsStockStatus { get; set; }
        public bool IsSaleStatus { get; set; }
        public Guid ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        public Product()
        {
            IsSaleStatus = true;
            IsStockStatus = true;
        }
    }
}
