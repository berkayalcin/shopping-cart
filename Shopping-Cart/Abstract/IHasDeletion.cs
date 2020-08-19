using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Has Deletion Time and Deletor
    /// </summary>
    public interface IHasDeletion
    {
        public DateTime DeletionTime { get; set; }
        public int DeletorUserId { get; set; }
    }
}
