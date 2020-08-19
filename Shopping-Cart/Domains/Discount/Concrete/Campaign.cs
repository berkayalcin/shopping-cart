using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.Discount.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Domains.Discount.Concrete
{
    /// <summary>
    /// Campaign
    /// </summary>
    public class Campaign : Discount
    {
        private int _minimumItem;
        private Category _category;
        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
        }

        /// <summary>
        /// Category To Apply Discount
        /// </summary>
        public Category Category
        {
            get { return _category; }
        }


        /// <summary>
        /// Required Minimum Item
        /// </summary>
        public int MinimumItem
        {
            get { return _minimumItem; }
        }



        /// <summary>
        /// Campaign
        /// </summary>
        /// <param name="category">Category To Apply Discount</param>
        /// <param name="amount">Discount Amount</param>
        /// <param name="minimumItem">Required Minimum Item </param>
        /// <param name="discountType">Discount Type</param>
        public Campaign(Category category, double amount, int minimumItem, DiscountType discountType) : base(discountType, amount)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (minimumItem < 0)
                throw new ArgumentException("Minimum Item Must Be Greather Than Or Equal To 0");


            _category = category;
            _minimumItem = minimumItem;
            _categoryId = category.Id;
        }


    }
}
