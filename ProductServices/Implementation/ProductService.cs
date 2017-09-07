using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductData;
using ProductDAL.UnitOfWork;

namespace ProductServices.Implementation
{
    class ProductService : Service, IProductService
    {
        public ProductService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {

        }

        public void AddProduct(Product product)
        {
            this._ProductUnitOfWork.Products.Add(product);
            this._ProductUnitOfWork.Commit();
        }

        public void DeleteProuct(Guid ID)
        {
            this._ProductUnitOfWork.Products.RemoveByKey(ID);
        }

        public Product FindProductByID(Guid ID)
        {
            return this._ProductUnitOfWork.Products.Get(ID);
        }

        public Product FindProductByName(string name)
        {
            return this._ProductUnitOfWork.Products.GetAll().Where(entity => entity.Name == name).SingleOrDefault();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return this._ProductUnitOfWork.Products.GetAll();
        }

        public void UpdateProduct(Guid productID, Product product)
        {
            var productToUpdate = _ProductUnitOfWork.Products.Get(productID);
            productToUpdate = product;
            this._ProductUnitOfWork.Commit();
        }
    }
}
