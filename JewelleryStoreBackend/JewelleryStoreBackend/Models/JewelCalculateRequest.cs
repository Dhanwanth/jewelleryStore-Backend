using System;

namespace JewelleryStoreBackend.Models
{
    public class JewelCalculateRequest
    {
        public Decimal GoldPriceInGram { get; set; }

        public Decimal Weight { get; set; }

        public bool IsDiscounted { get; set; }

        public Decimal DiscountedValue { get; set; }
    }
}
