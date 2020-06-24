using DAL.Context;
using DAL.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class ShopTypeRepository :RepositoryBase<ShopType>,IShopTypeRepository
    {
        public ShopTypeRepository(StorageDBContext context) : base(context)
        {}
    }
}
