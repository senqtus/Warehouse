using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUOW:IDisposable
    {
        IProductRepository Product { get; }
        IShopRepository Shop { get; }
        IShopTypeRepository ShopType { get; }
        void Commit();
    }
}
