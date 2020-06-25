using BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Warehouse.Models
{
    public class ProductListVM
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
