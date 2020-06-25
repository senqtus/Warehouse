using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShopOperations
    {
        IEnumerable<ShopDTO> GetAllShops();
        IEnumerable<ShopDTO> SearchShopBy(string property, string value);
        ShopComponents GetComponents();
        ShopFormDTO GetEditShopData(int Id);
        ShopDTO GetShop(int Id);
        void Create(ShopFormDTO model);
        void Edit(ShopFormDTO model);
        void Delete(int Id);
        void AddShopProduct(ShopProductDTO model);
        void DeleteProd(int Id);
    }
}
