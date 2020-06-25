using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopProductDTO
    {
        public int Id { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("([0-9]+)",ErrorMessage ="Use Only Digits")]
        public string BarCode { get; set; }
        [Required]
        [Range(0,999.9)]
        public double Price { get; set; }
    }
}
