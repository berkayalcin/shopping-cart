using FluentAssertions;
using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.Discount.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using Xunit;

namespace Shopping_Cart_XUnitTest
{
    public class DiscountTest
    {
        [Fact]
        public void MinusOneAmountCampaignShouldThrowArgumentNull()
        {
            Action act = () => new Campaign(new Category(""), -1, 0, Shopping_Cart.Domains.Discount.Enums.DiscountType.Rate);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void EmptyCategoryCampaignShouldThrowArgumentNull()
        {
            Action act = () => new Campaign(null, 1, 0, Shopping_Cart.Domains.Discount.Enums.DiscountType.Rate);
            act.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void MinusOneRequiredItemCampaignShouldThrowArgumentNull()
        {
            Action act = () => new Campaign(new Category(""), 1, -1, Shopping_Cart.Domains.Discount.Enums.DiscountType.Rate);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MinusOneAmountCouponShouldThrowArgumentNull()
        {
            Action act = () => new Coupon(1, Shopping_Cart.Domains.Discount.Enums.DiscountType.Rate, -1);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void MinusOneRequiredTotalAmountCouponShouldThrowArgumentNull()
        {
            Action act = () => new Coupon(-1, Shopping_Cart.Domains.Discount.Enums.DiscountType.Rate, 1);
            act.Should().Throw<ArgumentException>();
        }




    }
}
