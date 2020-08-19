using Shopping_Cart.Domains.Discount.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Cart.Domains.Discount.Satisfactions
{
    public class DiscountSatisfactions
    {
        public static bool IsCampaignItemCountSatisfied(ICollection<ShoppingCartItem> shoppingCartItems, Campaign campaign)
        {
            return shoppingCartItems.Count >= campaign.MinimumItem;
        }

        public static bool IsCouponTotalSatisfied(ShoppingCart.Concrete.ShoppingCart cart, Coupon coupon)
        {
            double totalPrice = cart.ShoppingCartItems.Sum(item => item.Quantity * item.Product.Price);
            totalPrice -= cart.GetCampaignDiscounts();
            return totalPrice >= coupon.MinimumCartTotal;
        }
    }
}
