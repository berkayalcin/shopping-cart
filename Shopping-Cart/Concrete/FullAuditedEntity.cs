using Shopping_Cart.Abstract;
using System;

namespace Shopping_Cart.Concrete
{
    /// <summary>
    /// Full Audited Entity
    /// </summary>
    public class FullAuditedEntity : FullAuditedEntity<int>
    {

    }

    /// <summary>
    /// Full Audited Entity
    /// </summary>
    /// <typeparam name="TKey">Primary Key</typeparam>
    public class FullAuditedEntity<TKey> : IFullAuditedEntity<TKey> where TKey : struct
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public int? CreatorUserId { get; set; }
        public DateTime LastModificationTime { get; set; }
        public int LastModifierId { get; set; }
        public DateTime DeletionTime { get; set; }
        public int DeletorUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
