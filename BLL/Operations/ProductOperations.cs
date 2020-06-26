using AutoMapper;
using BLL.DTOs.Product;
using BLL.Interfaces;
using DAL.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IUOW services;
        private readonly IMapper mapper;

        public ProductOperations(IUOW services,IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        public void Create(ProductFormDTO product)
        {
            Product dbModel = mapper.Map<Product>(product);
            services.Product.Create(dbModel);
            services.Commit();
        }

        public void Delete(int Id)
        {
            Product dbModel = services.Product.Get(Id);
            if(dbModel == null)
            {
                throw new Exception("Object not found");
            }
            if (dbModel.Shops.Count == 0) { 
                services.Product.Delete(dbModel);
                services.Commit();
            }
        }

        public void Edit(ProductFormDTO model)
        {
            var dbModel = services.Product.Get(model.Id);
            if (dbModel == null)
                throw new Exception("Object not found");
            mapper.Map<ProductFormDTO, Product>(model, dbModel);
            services.Product.Update(dbModel);
            services.Commit();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return mapper.Map<IEnumerable<ProductDTO>>(services.Product.FindAll());
        }

        public ProductFormDTO GetEditProductData(int Id)
        {
           return mapper.Map<ProductFormDTO>(services.Product.Get(Id));
        }

        public IEnumerable<ProductDTO> SearchProductBy(string property, string value)
        {
            if(property == "Name")
                return mapper.Map<IEnumerable<ProductDTO>>(services.Product.FindByCondition(x=>x.Name.Contains(value)));
            return mapper.Map<IEnumerable<ProductDTO>>(services.Product.FindByCondition(x => x.Manufacturer.Contains(value)));
        }
    }
}
