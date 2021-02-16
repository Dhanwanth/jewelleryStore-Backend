using NUnit.Framework;
using JewelleryStoreBackend.BusinessLayer;
using JewelleryStoreBackend.Models;

namespace JewelleryStoreBackend_UnitandIntegration.BusinessLayerTests
{
    public class JewelleryCalculatorTest
    {
        [Test]
        public void OneGramTestPositive()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4480.1234m;
            mockJewellery.IsDiscounted = false;
            mockJewellery.Weight = 1;
            mockJewellery.DiscountedValue = 884;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //Assert
            Assert.AreEqual(mockJewellery.GoldPriceInGram, charge);

        }

        [Test]
        public void OneGramTestPositiveWithZeroDiscount()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4480.1234m;
            mockJewellery.IsDiscounted = true;
            mockJewellery.Weight = 1;
            mockJewellery.DiscountedValue = 0;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //Assert
            Assert.AreEqual(mockJewellery.GoldPriceInGram, charge);

        }

        [Test]
        public void ZeroGramTestPositive()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4480.1234m;
            mockJewellery.IsDiscounted = true;
            mockJewellery.Weight = 0;
            mockJewellery.DiscountedValue = 0;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //Assert
            Assert.AreEqual(0, charge);

        }

        [Test]
        public void ZeroGramTestNegativeWithDiscount()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4480.1234m;
            mockJewellery.IsDiscounted = true;
            mockJewellery.Weight = 0;
            mockJewellery.DiscountedValue = 123;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //Assert
            //if value is negative should return zero
            Assert.AreEqual(0, charge);

        }

        [Test]
        public void OneGramTestNegativeWithZeroGoldPrice()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 0;
            mockJewellery.IsDiscounted = false;
            mockJewellery.Weight = 1;
            mockJewellery.DiscountedValue = 884;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //if value is negative should result 0
            //Assert
            Assert.AreEqual(mockJewellery.GoldPriceInGram, charge);
        }

        [Test]
        public void OneGramTestNegativeWithGoldPrice()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4430;
            mockJewellery.IsDiscounted = true;
            mockJewellery.Weight = 1;
            mockJewellery.DiscountedValue = 4431;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //if value is negative should result 0
            //Assert
            Assert.AreEqual(0, charge);
        }

        [Test]
        public void TestsNormalFlowPositiveWithoutDiscount()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4430;
            mockJewellery.IsDiscounted = false;
            mockJewellery.Weight = 2;
            mockJewellery.DiscountedValue = 4431;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //if value is negative should result 0
            //Assert
            Assert.AreEqual(mockJewellery.GoldPriceInGram * 2, charge);
        }

        [Test]
        public void TestsNormalFlowPositiveWithDiscount()
        {
            //Arrange
            var mockJewellery = new JewelCalculateRequest();
            mockJewellery.GoldPriceInGram = 4430;
            mockJewellery.IsDiscounted = true;
            mockJewellery.Weight = 2;
            mockJewellery.DiscountedValue = 884;

            //Act
            var charge = JewelCalculator.PriceConverter(mockJewellery);

            //if value is negative should result 0
            //Assert
            Assert.AreEqual((mockJewellery.GoldPriceInGram * 2)-884, charge);
        }

    }
}