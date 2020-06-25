using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Product
{
    public class ProductFormDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Thumb { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public IFormFile file { get; set; }
    }
}
