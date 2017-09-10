using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductData;
using ProductServices.Models;
using ProductCore.Abstraction.Interface.Mappers;
using ProductCore.Implementation.Mappers;
using ProductDAL.UnitOfWork;

namespace ProductServices.Implementation
{
    public class ProductService : Service, IProductService
    {
        public ProductService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {

        }
        public ProductService(IProductUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        private IEntityModelMapper<Product, ProductModel> _mapper = new EntityModelMapper<Product, ProductModel>();


        public void AddProduct(ProductModel product)
        {
            var ProductContext = _mapper.MapFromModelToEntity(product);
            this._ProductUnitOfWork.Products.Add(ProductContext);
            this._ProductUnitOfWork.Commit();
        }

        public void DeleteProduct(Guid ID)
        {
            this._ProductUnitOfWork.Products.RemoveByKey(ID);
            this._ProductUnitOfWork.Commit();
        }


        public void UpdateProduct(Guid productID, ProductModel product)
        {
            var productToUpdate = _ProductUnitOfWork.Products.Get(productID);
            this._mapper.MapFromModelToExistEntity(product, productToUpdate);
            this._ProductUnitOfWork.Commit();
        }

        ProductModel IProductService.FindProductByID(Guid ID)
        {
            var ProductContext = this._ProductUnitOfWork.Products.Get(ID);
            return this._mapper.MapFromEntityToModel(ProductContext);
        }

        ProductModel IProductService.FindProductByName(string name)
        {
            var ProductContext = this._ProductUnitOfWork.Products.GetAll()?.Where(entity => entity.Name == name)?.SingleOrDefault();
            return this._mapper.MapFromEntityToModel(ProductContext);
        }

        IEnumerable<ProductModel> IProductService.GetAllProduct()
        {
            var productModels = this._ProductUnitOfWork.Products.GetAll();
            return _mapper.MapFromEntityRangeToModels(productModels);
        }
    }
}
