using DAL.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private StorageDBContext Context;
        private IProductRepository productRepository;
        private IShopRepository shopRepository;
        private IShopTypeRepository shopTypeRepository;

        public UOW(StorageDBContext context)
        {
            Context = context;
        }
        public IProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(Context);
                return productRepository;
            }
        }

        public IShopRepository Shop
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(Context);
                return shopRepository;
            }
        }

        public IShopTypeRepository ShopType
        {
            get
            {
                if (shopTypeRepository == null)
                    shopTypeRepository = new ShopTypeRepository(Context);
                return shopTypeRepository;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
