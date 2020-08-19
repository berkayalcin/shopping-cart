using Shopping_Cart.Domains.Discount.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Cart.Domains.Discount.Satisfactions
{
    /// <summary>
    /// Discount Satisfactions
    /// </summary>
    public class DiscountSatisfactions
    {
        /// <summary>
        /// Checks Is Campaign Applyable For Cart Items
        /// </summary>
        /// <param name="shoppingCartItems">Cart Items</param>
        /// <param name="campaign">Campaign</param>
        /// <returns></returns>
        public static bool IsCampaignItemCountSatisfied(ICollection<ShoppingCartItem> shoppingCartItems, Campaign campaign)
        {
            return shoppingCartItems.Count >= campaign.MinimumItem;
        }
        /// <summary>
        /// Checks Is Coupon Applyable For Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public static bool IsCouponTotalSatisfied(ShoppingCart.Concrete.ShoppingCart cart, Coupon coupon)
        {
            double totalPrice = cart.ShoppingCartItems.Sum(item => item.Quantity * item.Product.Price);
            totalPrice -= cart.GetCampaignDiscounts();
            return totalPrice >= coupon.MinimumCartTotal;
        }
    }
}
