using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
    public class CategoryDTO
    {
       

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

       // public ICollection<Product> Products { get; private set; }
    }
}


