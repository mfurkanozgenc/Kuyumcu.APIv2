using Ardalis.SmartEnum;

namespace Kuyumcu.API.Domain.Enums
{
    public sealed class StockMovementTypeEnum : SmartEnum<StockMovementTypeEnum>
    {
        public static readonly StockMovementTypeEnum ProductEntry = new("Ürün Girişi",1);
        public static readonly StockMovementTypeEnum ProductRelease = new("Ürün Çıkışı",2);
        public StockMovementTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
