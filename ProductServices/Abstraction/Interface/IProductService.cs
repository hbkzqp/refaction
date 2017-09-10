using ProductServices.Models;
using System;
using System.Collections.Generic;

namespace ProductServices.Interface
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProduct();
        ProductModel FindProductByName(string name);
        ProductModel FindProductByID(Guid ID);
        void AddProduct(ProductModel product);
        void UpdateProduct(Guid productID, ProductModel product);
        void DeleteProduct(Guid ID);
    }
}
