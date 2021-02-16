using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JewelleryStoreBackend.Models;
using JewelleryStoreBackend.BusinessLayer;

namespace JewelleryStoreBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JewelleryCalculatorController : ControllerBase
    {
        private readonly ILogger<JewelleryCalculatorController> _logger;
        private static int DISCOUNT_PERCENTAGE = 2;

        public JewelleryCalculatorController(ILogger<JewelleryCalculatorController> logger)
        {
            _logger = logger;
        }

        [Route("/calculateCharges")]
        [HttpPost]
        public Decimal CalculatePrice(JewelCalculateRequest calculateRequest)
        {
            return JewelCalculator.PriceConverter(calculateRequest);
        }

        [Route("/discount")]
        [HttpGet]
        public Discount Discount()
        {
            Discount discount = new Discount();
            discount.DiscountInPercentage = DISCOUNT_PERCENTAGE;
            //TODO change discount to fetch from DB
            return discount;
        }

        [Route("/modifyDiscount")]
        [HttpPost]
        public ActionResult<bool> ModifyDiscount(int discount)
        {
            Console.WriteLine($"discount: {discount}");
            if (discount < 100 && discount > 0)
            {
                Console.WriteLine($"discount value: in");

                DISCOUNT_PERCENTAGE = discount;
                return Ok(true);
            }
            Console.WriteLine($"discount value: out");
            return Ok(false);
        }

    }
}
