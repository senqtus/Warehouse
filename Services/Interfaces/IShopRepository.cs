using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Interfaces
{
    public interface IShopRepository : IRepositoryBase<Shop>
    {
        IEnumerable<Shop> GetShops();
        Shop GetShopWithProducts(int Id);
        void AddProductShop(ProductShop model);
        void DeleteProductShop(int Id);
        IEnumerable<Shop> FindByConditionWithType(Expression<Func<Shop, bool>> expression);
    }
}
