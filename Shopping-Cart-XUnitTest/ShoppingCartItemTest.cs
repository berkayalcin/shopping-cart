using FluentAssertions;
using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using Xunit;

namespace Shopping_Cart_XUnitTest
{
    public class ShoppingCartItemTest
    {
        [Fact]
        public void EmptyProductShoppingCartItemThrowArgumentNull()
        {
            Action act = () => new ShoppingCartItem(null, 1);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MinusOneQuantityShoppingCartItemThrowArgument()
        {
            Action act = () => new ShoppingCartItem(new Product("",1,new Category("")), -1);
            act.Should().Throw<ArgumentException>();
        }

    




    }
}
