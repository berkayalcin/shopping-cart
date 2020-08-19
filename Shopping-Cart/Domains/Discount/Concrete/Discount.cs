using Shopping_Cart.Concrete;
using Shopping_Cart.Domains.Discount.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shopping_Cart.Domains.Discount.Concrete
{

    /// <summary>
    /// Base Discount Entity
    /// </summary>
    public abstract class Discount : FullAuditedEntity<int>
    {
        private double _amount;
        private DiscountType _discountType;


        /// <summary>
        /// Discount Type
        /// </summary>
        public DiscountType DiscountType
        {
            get { return _discountType; }
        }

        /// <summary>
        /// Discount Amount
        /// </summary>
        public double Amount
        {
            get { return _amount; }
        }


        /// <summary>
        /// Discount
        /// </summary>
        /// <param name="discountType">Discount Type</param>
        /// <param name="amount">Discount Amount</param>
        protected Discount(DiscountType discountType, double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount Must Be Greather Than Or Equal To 0");

            _discountType = discountType;
            _amount = amount;
        }

        /// <summary>
        /// Calculates Discount By Price
        /// </summary>
        /// <param name="price">Price</param>
        /// <returns></returns>
        public double DiscountByPrice(double price)
        {
            switch (_discountType)
            {
                case DiscountType.Rate:
                    return (price) / 100 * _amount;
                case DiscountType.Amount:
                    return _amount;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        /// <summary>
        /// Applies Discount To Price
        /// </summary>
        /// <param name="price">Price</param>
        /// <returns></returns>
        public double ApplyDiscount(double price)
        {
            price -= DiscountByPrice(price);
            return price;
        }







    }
}
