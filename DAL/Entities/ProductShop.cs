using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class ProductShop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public double Price { get; set; }
        public Shop Shop { get; set; }
        public Product Product {get;set;}
    }
}
