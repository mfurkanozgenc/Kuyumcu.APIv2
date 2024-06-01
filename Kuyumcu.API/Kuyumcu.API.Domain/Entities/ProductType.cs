using Kuyumcu.API.Domain.Abstractions;

namespace Kuyumcu.API.Domain.Entities
{
    public sealed class ProductType : BranchEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
    }
}
