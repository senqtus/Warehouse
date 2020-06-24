using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }
        public ICollection<ProductShop> Products { get; set; }
    }
}
