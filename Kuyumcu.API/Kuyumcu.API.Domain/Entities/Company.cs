using Kuyumcu.API.Domain.Abstractions;

namespace Kuyumcu.API.Domain.Entities
{
    public sealed class Company : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Branch>? Branches { get; set; }
    }
}
