using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductRepository :IRepositoryBase<Product>
    {
        Product GetProductWithShops(int Id);
    }
}
