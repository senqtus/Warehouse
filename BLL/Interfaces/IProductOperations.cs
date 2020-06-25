using BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductOperations
    {
        IEnumerable<ProductDTO> GetAllProducts();
        IEnumerable<ProductDTO> SearchProductBy(string property, string value);
        ProductFormDTO GetEditProductData(int Id);
        void Create(ProductFormDTO product);
        void Edit(ProductFormDTO model);
        void Delete(int Id);
    }
}
