using FluentAssertions;
using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using Xunit;

namespace Shopping_Cart_XUnitTest
{
    public class ProductTest
    {
        [Fact]
        public void ShouldEmptyTitleProductThrowException()
        {
            Action act = () => new Product(null, 1, new Category("Title"));
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldEmptyCategoryProductThrowException()
        {
            Action act = () => new Product("Title", 1, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldMinusOnePriceProductThrowException()
        {
            Action act = () => new Product("Title", -1, new Category("Title"));
            act.Should().Throw<ArgumentNullException>();
        }





    }
}
