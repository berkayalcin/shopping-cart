using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Audited Entity
    /// </summary>
    /// <typeparam name="TKey">Primary Key</typeparam>
    public interface IAuditedEntity<TKey> : IEntity<TKey>, IPassivable, IHasCreation where TKey : struct
    {

    }
    /// <summary>
    /// Audited Entity
    /// </summary>
    public interface IAuditedEntity : IAuditedEntity<int>
    {

    }
}
