using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Mark Has Creation Audits
    /// </summary>
    public interface IHasCreation
    {
        public DateTime CreationTime { get; set; }
        public int? CreatorUserId { get; set; }
    }
}
