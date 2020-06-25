using AutoMapper;
using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductFormDTO, Product>();
            CreateMap<Product, ProductFormDTO>();
            CreateMap<Shop, ShopDTO>()
                .ForMember(dest =>
                dest.Type,
                opt => opt.MapFrom(src => src.Type.Name));

            CreateMap<ShopFormDTO, Shop>();
            CreateMap<Shop, ShopFormDTO>();
            CreateMap<ShopProductDTO, ProductShop>()
                .ForMember(dest =>
                dest.Product,
                opt => opt.MapFrom(src => new Product() { Id = src.ProductId }))
                .ForMember(dest =>
                dest.Shop,
                opt => opt.MapFrom(src => new Shop() { Id = src.ShopId  }));
        }
    }
}
