using FluentAssertions;
using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using Xunit;

namespace Shopping_Cart_XUnitTest
{
    public class CategoryTest
    {
        [Fact]
        public void ShouldEmptyTitleCategoryThrowException()
        {
            Action act = () => new Category(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CategoryTitleShouldBeNike()
        {
            var category = new Category("Nike");
            category.Should().Match<Category>((x) => x.Title.Equals("Nike"));
        }




    }
}
