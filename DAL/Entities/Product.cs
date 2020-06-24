using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Manufacturer { get; set; }

        public ICollection<ProductShop> Shops { get; set; }
    }
}
