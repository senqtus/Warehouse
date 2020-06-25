using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopFormDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public string Address { get; set; }
        public List<int> Products { get; set; }
    }
}
