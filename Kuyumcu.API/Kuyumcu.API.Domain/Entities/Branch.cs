using Kuyumcu.API.Domain.Abstractions;

namespace Kuyumcu.API.Domain.Entities
{
    public sealed class Branch : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
