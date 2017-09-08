using ProductServices.Abstraction;
using ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductData;

namespace ProductServices.Implementation
{
    public class ProductOptionService : Service, IProductOptionService
    {
        public ProductOptionService(string ConnectionStringOrName) : base(ConnectionStringOrName)
        {
        }

        public void AddOption(Guid productID, ProductOption option)
        {
            this._ProductUnitOfWork.ProductOptions.Add(option);
            this._ProductUnitOfWork.Products.Get(productID).ProductOptions.Add(option);
            this._ProductUnitOfWork.Commit();
        }

        public void DeleteOption(Guid optionID)
        {
            this._ProductUnitOfWork.ProductOptions.RemoveByKey(optionID);
            this._ProductUnitOfWork.Commit();
        }

        public ProductOption GetExactOption(Guid productID, Guid optionID)
        {
           return this._ProductUnitOfWork.Products.Get(productID)?.ProductOptions?.Where(opt => opt.Id == optionID).SingleOrDefault();
        }

        public IEnumerable<ProductOption> GetOptionsByProductID(Guid productID)
        {
            return this._ProductUnitOfWork.Products.Get(productID)?.ProductOptions;
        }

        public void UpdateOption(Guid optionID, ProductOption option)
        {
            var optionToUpdate = this._ProductUnitOfWork.ProductOptions.Get(optionID);
            optionToUpdate = option;
            this._ProductUnitOfWork.Commit();
        }
    }
}
