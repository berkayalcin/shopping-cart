using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.Delivery.Concrete;
using Shopping_Cart.Domains.Discount.Concrete;
using Shopping_Cart.Domains.Discount.Satisfactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Cart.Domains.ShoppingCart.Concrete
{
    public class ShoppingCart
    {

        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<Campaign> _appliedCampaigns;
        private ICollection<Coupon> _appliedCoupons;
        private readonly double costPerDelivery;
        private readonly double costPerProduct;
        private readonly double fixedCost;

        /// <summary>
        /// Shopping Cart Items
        /// </summary>
        public ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems; }
        }

        public ShoppingCart(double costPerDelivery, double costPerProduct, double fixedCost = 2.99)
        {
            _shoppingCartItems = new List<ShoppingCartItem>();
            _appliedCampaigns = new List<Campaign>();
            _appliedCoupons = new List<Coupon>();
            this.costPerDelivery = costPerDelivery;
            this.costPerProduct = costPerProduct;
            this.fixedCost = fixedCost;
        }

        /// <summary>
        /// Adds Shopping Cart Item
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Product Quantity</param>
        public void AddItem(Product product, int quantity)
        {
            _shoppingCartItems.Add(new ShoppingCartItem(product, quantity));
        }


        /// <summary>
        /// Applies Campaign Discounts
        /// </summary>
        /// <param name="campaigns">Discount</param>
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            if (campaigns == null)
                throw new ArgumentNullException(nameof(campaigns));

            foreach (var campaign in campaigns)
            {
                if (!DiscountSatisfactions.IsCampaignItemCountSatisfied(_shoppingCartItems, campaign))
                    continue;
                _appliedCampaigns.Add(campaign);
            }
        }

        /// <summary>
        /// Applies Coupon To Shopping Cart
        /// </summary>
        /// <param name="coupon">Coupon</param>
        public void ApplyCoupon(Coupon coupon)
        {
            if (coupon == null)
                throw new ArgumentNullException(nameof(coupon));

            if (!DiscountSatisfactions.IsCouponTotalSatisfied(_shoppingCartItems, coupon))
                return;

            _appliedCoupons.Add(coupon);
        }

        /// <summary>
        /// Get Coupon Discounts
        /// </summary>
        /// <returns></returns>
        public double GetCouponDiscounts()
        {
            return _appliedCoupons.Sum(x => x.Amount);
        }

        /// <summary>
        /// Gets Campaign Discounts
        /// </summary>
        /// <returns></returns>
        public double GetCampaignDiscounts()
        {
            return _appliedCampaigns.Sum(x => x.Amount);
        }

        /// <summary>
        /// Gets Total Cart Amount After Discounts Applied
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmountAfterDiscounts()
        {
            double cartTotal = GetTotalAmount();
            foreach (var campaignDiscount in _appliedCampaigns)
            {
                cartTotal = campaignDiscount.ApplyDiscount(cartTotal);
            }
            foreach (var couponDiscount in _appliedCoupons)
            {
                cartTotal = couponDiscount.ApplyDiscount(cartTotal);
            }

            return cartTotal;
        }

        public void Print()
        {
            double totalCampaignDiscount = GetCampaignDiscounts();
            double totalCouponDiscount = GetCouponDiscounts();

            double perItemCouponDiscount = totalCouponDiscount / _shoppingCartItems.Count;


            var categoryGroups = _shoppingCartItems.GroupBy(x => x.Product.Category.Title);
            foreach (var category in categoryGroups)
            {
                string categoryName = category.Key;
                var categoryCampaigns = _appliedCampaigns.Where(x => x.Category.Title == category.Key);
                foreach (var shoppingCartItem in category)
                {
                    string productName = shoppingCartItem.Product.Title;
                    int quantity = shoppingCartItem.Quantity;
                    double unitPrice = shoppingCartItem.Product.Price;
                    double totalPrice = unitPrice * quantity;
                    double totalDiscount = 0;
                    double totalDiscountedPrice = totalPrice;
                    foreach (var campaignDiscount in categoryCampaigns)
                    {
                        totalDiscount += campaignDiscount.DiscountByPrice(totalDiscountedPrice);
                        totalDiscountedPrice = campaignDiscount.ApplyDiscount(totalDiscountedPrice);
                    }


                    Console.WriteLine($" Category : {categoryName} | Product :  {productName} |" +
                        $"Quantity : {quantity} | Unit Price : {unitPrice} | Total Price : {totalPrice} | Total Discount : {totalDiscount} \n");
                }
            }
            Console.WriteLine($"Total Amount    : {GetTotalAmountAfterDiscounts()}");
            Console.WriteLine($"Delivery Cost   : {GetDeliveryCost()}");
        }

        /// <summary>
        /// Gets Delivery Cost
        /// </summary>
        /// <param name="costPerDelivery">Cost Per Delivery</param>
        /// <param name="costPerProduct">Cost Per Product</param>
        /// <param name="fixedCost">Fixed Cost default 2.99 TL</param>
        /// <returns></returns>
        public double GetDeliveryCost() => new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost).CalculateFor(this);

        /// <summary>
        /// Gets Shopping Cart Total
        /// </summary>
        /// <returns></returns>
        private double GetTotalAmount() => _shoppingCartItems.Sum(item => item.Quantity * item.Product.Price);



    }
}
