using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Interface
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProduct();
        ProductModel FindProductByName(string name);
        ProductModel FindProductByID(Guid ID);
        Task AddProduct(ProductModel product);
        Task UpdateProduct(Guid productID, ProductModel product);
        Task DeleteProduct(Guid ID);
    }
}
