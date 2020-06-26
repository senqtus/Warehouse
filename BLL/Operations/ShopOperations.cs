using AutoMapper;
using BLL.DTOs.Shop;
using BLL.Interfaces;
using DAL.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class ShopOperations : IShopOperations
    {
        private readonly IUOW services;
        private readonly IMapper mapper;

        public ShopOperations(IUOW services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }
        public void Create(ShopFormDTO model)
        {
            Shop dbModel = mapper.Map<ShopFormDTO,Shop>(model);
            services.Shop.Create(dbModel);
            services.Commit();
        }

        public void Delete(int Id)
        {
            Shop dbModel = services.Shop.Get(Id);
            if (dbModel == null)
            {
                throw new Exception("Object not found");
            }
            if (dbModel.Products.Count == 0) { 
                services.Shop.Delete(dbModel);
                services.Commit();
            }
        }

        public void Edit(ShopFormDTO model)
        {
            Shop dbModel = services.Shop.Get(model.Id);
            if (dbModel == null)
            {
                throw new Exception("Object not found");
            }
            mapper.Map<ShopFormDTO, Shop>(model, dbModel);
            services.Shop.Update(dbModel);
            services.Commit();
        }

        public IEnumerable<ShopDTO> GetAllShops()
        {
            return mapper.Map<IEnumerable<ShopDTO>>(services.Shop.GetShops());
        }

        public ShopComponents GetComponents()
        {
            ShopComponents shopComponents = new ShopComponents();
            var types = services.ShopType.FindAll();
            shopComponents.ShopTypes = types.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = $"{x.Name}", Value = x.Id.ToString() }).ToList();
            var products = services.Product.FindAll();
            shopComponents.ProductsSelectList = products.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = $"{x.Name} - {x.Manufacturer}", Value = x.Id.ToString() }).ToList();
            return shopComponents;
        }

        public ShopFormDTO GetEditShopData(int Id)
        {
            return mapper.Map<ShopFormDTO>(services.Shop.Get(Id));
        }

        public IEnumerable<ShopDTO> SearchShopBy(string property, string value)
        {
            if (property == "Name")
                return mapper.Map<IEnumerable<ShopDTO>>(services.Shop.FindByConditionWithType(x => x.Name.Contains(value)));
            else if(property == "Type")
                return mapper.Map<IEnumerable<ShopDTO>>(services.Shop.FindByConditionWithType(x => x.Type.Name.Contains(value)));

            return mapper.Map<IEnumerable<ShopDTO>>(services.Shop.FindByConditionWithType(x => x.Address.Contains(value)));
        }

        public ShopDTO GetShop(int Id)
        {
            return mapper.Map<ShopDTO>(services.Shop.GetShopWithProducts(Id));
        }

        public void AddShopProduct(ShopProductDTO model)
        {
            ProductShop dbModel = mapper.Map<ProductShop>(model);
            services.Shop.AddProductShop(dbModel);
            services.Commit();
        }

        public void DeleteProd(int Id)
        {
            services.Shop.DeleteProductShop(Id);
        }

    }
}
