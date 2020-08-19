using Shopping_Cart.Domains.Discount.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Domains.Discount.Concrete
{
    /// <summary>
    /// Coupon
    /// </summary>
    public class Coupon : Discount
    {
        private double _minimumCartTotal;

        /// <summary>
        /// Required Card Total
        /// </summary>
        public double MinimumCartTotal
        {
            get { return _minimumCartTotal; }
        }

        /// <summary>
        /// Cart Coupon
        /// </summary>
        /// <param name="minimumCartTotal">Required Cart Total</param>
        /// <param name="discountType">Discount Type</param>
        /// <param name="amount">Discount Amount</param>
        public Coupon(double minimumCartTotal, DiscountType discountType, double amount) : base(discountType, amount)
        {
            if (minimumCartTotal < 0)
                throw new ArgumentException("Minimum Cart Total Must Be Greather Than Or Equal To 0");

            _minimumCartTotal = minimumCartTotal;
        }
    }
}
