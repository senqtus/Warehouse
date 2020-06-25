using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ShopDetailsVM
    {
        public ShopDTO Shop { get; set; }
        public ShopComponents Components { get; set; }
        public ShopProductDTO ShopProduct { get; set; }
    }
}
