using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ShopFormVM
    {
        public ShopFormDTO Shop { get; set; }
        public ShopComponents Components { get; set; }
    }
}
