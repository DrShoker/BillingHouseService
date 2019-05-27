using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Common.Models
{
    public class ListItemModel<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
