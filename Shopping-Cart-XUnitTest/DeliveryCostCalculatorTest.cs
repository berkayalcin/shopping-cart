using FluentAssertions;
using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.Delivery.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using Xunit;

namespace Shopping_Cart_XUnitTest
{
    public class DeliveryCostCalculatorTest
    {
        [Fact]
        public void MinusOneCostPerDeliveryCalculatorShouldThrowArgumentNull()
        {
            Action act = () => new DeliveryCostCalculator(-1, 1, 1);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MinusOneCostPerProductCalculatorShouldThrowArgumentNull()
        {
            Action act = () => new DeliveryCostCalculator(1, -1, 1);
            act.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void MinusOneFixedCostDeliveryCalculatorShouldThrowArgumentNull()
        {
            Action act = () => new DeliveryCostCalculator(1, 1, -1);
            act.Should().Throw<ArgumentNullException>();
        }


    }
}
