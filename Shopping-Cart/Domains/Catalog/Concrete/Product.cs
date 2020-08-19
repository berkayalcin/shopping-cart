using Shopping_Cart.Concrete;
using System;

namespace Shopping_Cart.Domains.Catalog.Concrete
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product : FullAuditedEntity<int>
    {


        private string _title;

        private double _price;
        private int _categoryId;
        private Category _category;

        /// <summary>
        /// Product Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Product Price
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }


        /// <summary>
        /// Product Category
        /// </summary>
        public virtual Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// Product
        /// </summary>
        /// <param name="title">Product Title</param>
        /// <param name="price">Product Unit Price</param>
        /// <param name="category">Product Category</param>
        public Product(string title, float price, Category category)
        {

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (price < 0)
                throw new ArgumentNullException(nameof(price));

            _title = title;
            _price = price;
            _category = category;
        }





    }
}
