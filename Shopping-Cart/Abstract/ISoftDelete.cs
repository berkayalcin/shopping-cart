using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Mark Class As Soft Deletable
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Is Entity Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
