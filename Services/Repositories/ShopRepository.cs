using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Services.Repositories
{
    public class ShopRepository :RepositoryBase<Shop>,IShopRepository
    {
        public ShopRepository(StorageDBContext context) :base(context)
        { }

        public void AddProductShop(ProductShop model)
        {
            var newmodel = Context.ProductShops.Where(x => x.ProductId == model.ProductId && x.ShopId == model.ShopId).FirstOrDefault();
            if (newmodel != null)
            {
                newmodel.Price = model.Price;
                newmodel.BarCode = model.BarCode;
                Context.ProductShops.Update(newmodel);
            }
            else
                Context.ProductShops.Add(new ProductShop() { ProductId = model.ProductId, ShopId = model.ShopId, BarCode = model.BarCode, Price = model.Price });

        }

        public void DeleteProductShop(int Id)
        {
            var model = Context.ProductShops.Where(x => x.Id == Id).FirstOrDefault();
            if(model != null)
                Context.ProductShops.Remove(model);
            Context.SaveChanges();
        }

        public IEnumerable<Shop> GetShops()
        {
            return Context.Shops.Include(x => x.Type);
        }

        public Shop GetShopWithProducts(int Id)
        {
            return Context.Shops.Where(x => x.Id == Id).Include(x => x.Products).FirstOrDefault();
        }

        public IEnumerable<Shop> FindByConditionWithType(Expression<Func<Shop, bool>> expression)
        {
            return Context.Shops.Where(expression).Include(x=>x.Type);
        }
    }
}
