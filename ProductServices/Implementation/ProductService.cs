﻿using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductData;
using ProductServices.Models;
using ProductCore.Abstraction.Interface.Mappers;
using ProductCore.Implementation.Mappers;
using ProductDAL.UnitOfWork;
using System.Threading.Tasks;

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


        public async Task AddProduct(ProductModel product)
        {
            using (var work = GetUnitOfWork())
            {
                var ProductContext = _mapper.MapFromModelToEntity(product);
                work.Products.Add(ProductContext);
                await work.Commit();
            }
            
        }

        public async Task DeleteProduct(Guid ID)
        {
            using (var work = GetUnitOfWork())
            {
                work.Products.RemoveByKey(ID);
                await work.Commit();
            }
            
        }


        public async Task UpdateProduct(Guid productID, ProductModel product)
        {
            using (var work = GetUnitOfWork())
            {
                var productToUpdate = work.Products.Get(productID);
                _mapper.MapFromModelToExistEntity(product, productToUpdate);
                await work.Commit();
            }
            
        }

        ProductModel IProductService.FindProductByID(Guid ID)
        {
            using (var work = GetUnitOfWork())
            {
                var ProductContext = work.Products.Get(ID);
                return _mapper.MapFromEntityToModel(ProductContext);
            }
            
        }

        ProductModel IProductService.FindProductByName(string name)
        {
            using (var work = GetUnitOfWork())
            {
                var ProductContext = work.Products.GetAll()?.Where(entity => entity.Name == name)?.SingleOrDefault();
                return _mapper.MapFromEntityToModel(ProductContext);
            }
            
        }

        IEnumerable<ProductModel> IProductService.GetAllProduct()
        {
            using (var work = GetUnitOfWork())
            {
                var productEntities = work.Products.GetAll();
                return _mapper.MapFromEntityRangeToModels(productEntities);
            }
           
        }
    }
}
