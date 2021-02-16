using NUnit.Framework;
using NSubstitute;
using JewelleryStoreBackend.Controllers;
using JewelleryStoreBackend.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JewelleryStoreBackend_UnitandIntegration.ControllerTests
{
    public class JewelCalculatorControllerTest
    {
        //Arrange
        private static ILogger<JewelleryCalculatorController> loggerMock = Substitute.For<ILogger<JewelleryCalculatorController>>();
        private static JewelleryCalculatorController JewelCalculatorController = new JewelleryCalculatorController(loggerMock);
        private static JewelCalculateRequest jewelCalculateRequestMock = new JewelCalculateRequest
        {
            GoldPriceInGram = 4429.123m,
            DiscountedValue = 884.5m,
            Weight = 1,
            IsDiscounted = false
        };
        
        [Test]
        public void CalculatePriceTestPositive()
        {
            //Act
            var result = JewelCalculatorController.CalculatePrice(jewelCalculateRequestMock);

            //Assert
            Assert.AreEqual(result, jewelCalculateRequestMock.GoldPriceInGram);

        }

        [Test]
        public void GetDiscountTest()
        {
            //Act
            var result = JewelCalculatorController.Discount();

            //Assert
            Assert.AreEqual(result.DiscountInPercentage, 2);

        }

        [Test]
        public void PostDiscountTestPositive()
        {
            //Act
            var result = JewelCalculatorController.ModifyDiscount(3);

            var expected = new ActionResult<bool>(true);

            //Assert
            Assert.AreEqual(JewelCalculatorController.Discount().DiscountInPercentage, 3);
        }

        [Test]
        public void PostDiscountTestNegative()
        {
            //Act
            var result = JewelCalculatorController.ModifyDiscount(300);

            //Except
            var expected = new ActionResult<bool>(false);

            //Assert
            Assert.AreEqual(JewelCalculatorController.Discount().DiscountInPercentage, 2);
            Assert.AreEqual(result.Value, expected.Value);
        }
    }
}
