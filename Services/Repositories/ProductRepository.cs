using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(StorageDBContext context) :base(context)
        { }

        public Product GetProductWithShops(int Id)
        {
            return Context.Products.Where(x => x.Id == Id).Include(x => x.Shops).FirstOrDefault();
        }
    }
}
