using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public List<ProductShop> Products { get; set; }
    }
}
