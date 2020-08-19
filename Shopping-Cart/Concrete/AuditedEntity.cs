using Shopping_Cart.Abstract;
using System;

namespace Shopping_Cart.Concrete
{
    /// <summary>
    /// Concrete Audited Entity,Integer Primary Key
    /// </summary>
    public abstract class AuditedEntity : AuditedEntity<int>
    {

    }

    /// <summary>
    /// Concrete Audited Entity
    /// </summary>
    /// <typeparam name="TKey">Primary Key</typeparam>
    public abstract class AuditedEntity<TKey> : IAuditedEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public int? CreatorUserId { get; set; }
    }

}
