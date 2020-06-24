using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductRepository :IRepositoryBase<Product>
    {
        /* IEnumerable<Product> GetAllProducts();
         IEnumerable<Product> SearchProductBy(string property, string value);*/
        Product GetProductWithShops(int Id);
    }
}
