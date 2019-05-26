using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Interfaces;

namespace BH.DTOL.Abstract
{
    public abstract class Entity<T> : TEntity<T> 
    {
        public T Id { get; set; }
        object IEntity.Id
        {
            get { return this.Id; }
            set { this.Id = (T)Convert.ChangeType(value, typeof(T)); }
        }
    }
}
