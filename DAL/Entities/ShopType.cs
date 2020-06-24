using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ShopType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Shop> Shops { get; set; }
    }
}
