using System;
using JewelleryStoreBackend.Models;

namespace JewelleryStoreBackend.BusinessLayer
{
    public static class JewelCalculator
    {
        public static decimal PriceConverter(JewelCalculateRequest calculateRequest) { 
           var result = calculateRequest switch
           {
               { IsDiscounted: true } => (calculateRequest.GoldPriceInGram * calculateRequest.Weight) - (calculateRequest.DiscountedValue),
               { IsDiscounted: false } => (calculateRequest.GoldPriceInGram * calculateRequest.Weight)
           };
            if (result < 0) return 0;
            return result;
        }
    }
}
