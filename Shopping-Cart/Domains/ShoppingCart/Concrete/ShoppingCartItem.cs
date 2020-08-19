using Shopping_Cart.Concrete;
using Shopping_Cart.Domains.Catalog.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Domains.ShoppingCart.Concrete
{
    /// <summary>
    /// Shopping Cart Item
    /// </summary>
    public class ShoppingCartItem
    {


        private int _productId;

        private Product _product;

        private int _quantity;

        /// <summary>
        /// Product Quantity
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
        }

        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
        }


        /// <summary>
        /// Product
        /// </summary>
        public Product Product
        {
            get { return _product; }
        }


        /// <summary>
        /// Shopping Cart Item
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Product Quantity</param>
        public ShoppingCartItem(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity < 0)
                throw new ArgumentException("Quantity Must Be Greather Than Or Equal To 0");

            _product = product;
            _quantity = quantity;
            _productId = product.Id;
        }




    }
}
