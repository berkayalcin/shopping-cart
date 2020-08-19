using Shopping_Cart.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;
using System.Linq;

namespace Shopping_Cart.Domains.Delivery.Concrete
{
    public class DeliveryCostCalculator
    {
        private double _costPerDelivery;
        private double _costPerProduct;
        private double _fixedCost;

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            if (costPerDelivery < 0)
                throw new ArgumentNullException(nameof(costPerDelivery));

            if (costPerProduct < 0)
                throw new ArgumentNullException(nameof(costPerProduct));

            if (fixedCost < 0)
                throw new ArgumentNullException(nameof(fixedCost));

            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _fixedCost = fixedCost;
        }

        /// <summary>
        /// Fixed Delivery Cost
        /// </summary>
        public double FixedCost
        {
            get { return _fixedCost; }
        }


        /// <summary>
        /// Cost Per Product
        /// </summary>
        public double CostPerProduct
        {
            get { return _costPerProduct; }
        }

        /// <summary>
        /// Cost Per Delivery
        /// </summary>
        public double CostPerDelivery
        {
            get { return _costPerDelivery; }
        }


        public double CalculateFor(ShoppingCart.Concrete.ShoppingCart cart)
        {
            int numberOfDeliveries = GetNumberOfDeliveries(cart);
            int numberOfProducts = GetNumberUniqueProducts(cart);
            return (numberOfDeliveries * _costPerDelivery) + (numberOfProducts * _costPerProduct) + _fixedCost;
        }

        /// <summary>
        /// Gets Number of deliveries
        /// </summary>
        /// <param name="cart">Shopping Cart</param>
        /// <returns></returns>
        private int GetNumberOfDeliveries(ShoppingCart.Concrete.ShoppingCart cart) =>
            cart.ShoppingCartItems.GroupBy(x => x.Product.Category.Title).Count();


        /// <summary>
        /// Gets Number of Unique Products
        /// </summary>
        /// <param name="cart">Shopping Cart</param>
        /// <returns></returns>
        private int GetNumberUniqueProducts(ShoppingCart.Concrete.ShoppingCart cart) =>
            cart.ShoppingCartItems.GroupBy(x => x.Product.Title).Count();







    }
}
