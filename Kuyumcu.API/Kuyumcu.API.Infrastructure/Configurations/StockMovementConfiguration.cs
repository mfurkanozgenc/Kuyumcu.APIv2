using Kuyumcu.API.Domain.Entities;
using Kuyumcu.API.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuyumcu.API.Infrastructure.Configurations
{
    public sealed class StockMovementConfiguration : IEntityTypeConfiguration<StokMovement>
    {
        public void Configure(EntityTypeBuilder<StokMovement> builder)
        {
            builder.Property(p => p.Type)
                   .HasConversion(type => type.Value, value => StockMovementTypeEnum.FromValue(value));
        }
    }
}
