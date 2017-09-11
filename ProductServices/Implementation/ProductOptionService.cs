using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using ProductData;
using ProductServices.Models;
using ProductCore.Implementation.Mappers;
using ProductCore.Abstraction.Interface.Mappers;
using ProductDAL.UnitOfWork;

namespace ProductServices.Implementation
{
    public class ProductOptionService : Service, IProductOptionService
    {
        public ProductOptionService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {
        }

        public ProductOptionService(IProductUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        private IEntityModelMapper<ProductOption, ProductOptionModel> _mapper = new EntityModelMapper<ProductOption, ProductOptionModel>();



        public void AddOption(Guid productID, ProductOptionModel option)
        {
            using (var work = GetUnitOfWork())
            {
                var optionEntity = _mapper.MapFromModelToEntity(option);
                work.ProductOptions.Add(optionEntity);
                work.Products.Get(productID).ProductOptions.Add(optionEntity);
                work.Commit();
            }
               
        }

        public void DeleteOption(Guid optionID)
        {
            using (var work = GetUnitOfWork())
            {
                work.ProductOptions.RemoveByKey(optionID);
                work.Commit();
            }
            
        }
        public void UpdateOption(Guid optionID, ProductOptionModel option)
        {
            using (var work = GetUnitOfWork())
            {
                var optionToUpdate = work.ProductOptions.Get(optionID);
                _mapper.MapFromModelToExistEntity(option, optionToUpdate);
                work.Commit();
            }
        }

        ProductOptionModel IProductOptionService.GetExactOption(Guid productID, Guid optionID)
        {
            using (var work = GetUnitOfWork())
            {
                var optionEntity = work.ProductOptions.SingleOrDefault(opt => (opt.ProductId == productID && opt.Id == optionID));
                return _mapper.MapFromEntityToModel(optionEntity);
            }
           
        }

        IEnumerable<ProductOptionModel> IProductOptionService.GetOptionsByProductID(Guid productID)
        {
            using (var work = GetUnitOfWork())
            {
                var optionEntities = work.ProductOptions.Find(opt => opt.ProductId == productID);
                return _mapper.MapFromEntityRangeToModels(optionEntities);
            }
            
        }
    }
}
