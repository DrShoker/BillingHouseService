using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DTOL.Interfaces
{
    public interface IEntity
    {
        object Id { get; set; }
    }

    public interface TEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
