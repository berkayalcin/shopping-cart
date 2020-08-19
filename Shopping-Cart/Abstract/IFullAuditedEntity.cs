using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Full Audited Entity
    /// </summary>
    public interface IFullAuditedEntity : IFullAuditedEntity<int>
    {
    }

    /// <summary>
    /// Full Audited Entity
    /// </summary>
    /// <typeparam name="TKey">Primary Key</typeparam>
    public interface IFullAuditedEntity<TKey> : IAuditedEntity<TKey>, IHasModification, IHasDeletion, ISoftDelete where TKey : struct
    {

    }
}
