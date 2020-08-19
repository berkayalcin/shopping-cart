using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart.Abstract
{
    /// <summary>
    /// Abstract Entity
    /// </summary>
    /// <typeparam name="T">Primary Key</typeparam>
    public interface IEntity<T> where T : struct
    {
        public T Id { get; set; }
    }

    /// <summary>
    /// Abstract Entity Has Integer Primary Key
    /// </summary>
    public interface IEntity : IEntity<int>
    {

    }
}
