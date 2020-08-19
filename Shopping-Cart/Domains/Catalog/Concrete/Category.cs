using Shopping_Cart.Concrete;
using System;
using System.Collections.Generic;

namespace Shopping_Cart.Domains.Catalog.Concrete
{
    /// <summary>
    /// Category Entity
    /// </summary>
    public class Category : FullAuditedEntity<int>
    {

        private string _title;
        /// <summary>
        /// Category Title
        /// </summary>


        private int _parentId;
        private Category _parent;
        private ICollection<Category> _childs;

        /// <summary>
        /// Child Categories
        /// </summary>
        public ICollection<Category> Childs
        {
            get { return _childs; }
            set { _childs = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Parent Id
        /// </summary>
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public Category Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// Category
        /// </summary>
        /// <param name="title">Category Title</param>
        /// <param name="parentId">Optional Parent Id</param>
        public Category(string title, Category? parent = null)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            _title = title;

            if (parent != null)
            {
                _parent = parent;
                _parentId = parent.Id;
            }
        }




    }
}
