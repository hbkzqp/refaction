using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Interface
{
    interface IProductService
    {
        IEnumerable<Product> GetAllProduct();
        Product FindProductByName(string name);
        Product FindProductByID(Guid ID);
        void AddProduct(Product product);
        void UpdateProduct(Guid productID, Product product);
        void DeleteProuct(Guid ID);
    }
}
