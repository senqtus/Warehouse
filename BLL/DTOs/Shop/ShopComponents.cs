using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopComponents
    {
        public List<SelectListItem> ShopTypes { get; set; }
        public List<SelectListItem> ProductsSelectList { get; set; }
    }
}
