using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Has Modification Time and Last Modifier User
    /// </summary>
    public interface IHasModification
    {
        public DateTime LastModificationTime { get; set; }
        public int LastModifierId { get; set; }
    }
}
