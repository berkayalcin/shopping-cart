using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Mark as Passivable Entity
    /// </summary>
    public interface IPassivable
    {
        /// <summary>
        /// Is Entity Active
        /// </summary>
        public bool IsActive { get; set; }
    }
}
