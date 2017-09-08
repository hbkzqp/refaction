using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductData;
using ProductServices.Models;
using ProductCore.Abstraction.Interface.Mappers;
using ProductCore.Implementation.Mappers;

namespace ProductServices.Implementation
{
    public class ProductService : Service, IProductService
    {
        public ProductService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {

        }

        private IEntityModelMapper<Product, ProductModel> _mapper = new EntityModelMapper<Product, ProductModel>();




        public void AddProduct(ProductModel product)
        {
            var productEntity = _mapper.MapFromModelToEntity(product);
            this._ProductUnitOfWork.Products.Add(productEntity);
            this._ProductUnitOfWork.Commit();
        }

        public void DeleteProuct(Guid ID)
        {
            this._ProductUnitOfWork.Products.RemoveByKey(ID);
        }





        public void UpdateProduct(Guid productID, ProductModel product)
        {
            var productToUpdate = _ProductUnitOfWork.Products.Get(productID);
            productToUpdate = this._mapper.MapFromModelToEntity(product);
            this._ProductUnitOfWork.Commit();
        }

        ProductModel IProductService.FindProductByID(Guid ID)
        {
            var productEntity = this._ProductUnitOfWork.Products.Get(ID);
            return this._mapper.MapFromEntityToModel(productEntity);
        }

        ProductModel IProductService.FindProductByName(string name)
        {
            var productEntity = this._ProductUnitOfWork.Products.GetAll()?.Where(entity => entity.Name == name)?.SingleOrDefault();
            return this._mapper.MapFromEntityToModel(productEntity);
        }

        IEnumerable<ProductModel> IProductService.GetAllProduct()
        {
            var productModels = this._ProductUnitOfWork.Products.GetAll();
            return _mapper.MapFromEntityRangeToModels(productModels);
        }
    }
}
