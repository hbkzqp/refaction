using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductData;
using ProductServices.Models;
using ProductCore.Implementation.Mappers;
using ProductCore.Abstraction.Interface.Mappers;

namespace ProductServices.Implementation
{
    public class ProductOptionService : Service, IProductOptionService
    {
        public ProductOptionService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {
        }
        private IEntityModelMapper<ProductOption, ProductOptionModel> _mapper = new EntityModelMapper<ProductOption, ProductOptionModel>();



        public void AddOption(Guid productID, ProductOptionModel option)
        {
            var optionEntity = this._mapper.MapFromModelToEntity(option);
            this._ProductUnitOfWork.ProductOptions.Add(optionEntity);
            this._ProductUnitOfWork.Products.Get(productID).ProductOptions.Add(optionEntity);
            this._ProductUnitOfWork.Commit();
        }

        public void DeleteOption(Guid optionID)
        {
            this._ProductUnitOfWork.ProductOptions.RemoveByKey(optionID);
            this._ProductUnitOfWork.Commit();
        }
        public void UpdateOption(Guid optionID, ProductOptionModel option)
        {
            var optionToUpdate = this._ProductUnitOfWork.ProductOptions.Get(optionID);
            this._mapper.MapFromModelToExistEntity(option, optionToUpdate);
            this._ProductUnitOfWork.Commit();

        }

        ProductOptionModel IProductOptionService.GetExactOption(Guid productID, Guid optionID)
        {

            var optionEntity =
                this._ProductUnitOfWork.ProductOptions.SingleOrDefault(opt => (opt.ProductId == productID && opt.Id == optionID));
            return this._mapper.MapFromEntityToModel(optionEntity);
        }

        IEnumerable<ProductOptionModel> IProductOptionService.GetOptionsByProductID(Guid productID)
        {
            var optionEntities = this._ProductUnitOfWork.ProductOptions.Find(opt => opt.ProductId == productID);
            return this._mapper.MapFromEntityRangeToModels(optionEntities);
        }
    }
}
