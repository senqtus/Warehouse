﻿using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ShopListVM
    {
        public IEnumerable<ShopDTO> Shops { get; set; }
    }
}
