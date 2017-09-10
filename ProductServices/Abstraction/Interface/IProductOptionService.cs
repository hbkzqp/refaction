using ProductData;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Interface
{
    public interface IProductOptionService
    {
        IEnumerable<ProductOptionModel> GetOptionsByProductID(Guid productID);
        ProductOptionModel GetExactOption(Guid productID, Guid optionID);
        void AddOption(Guid productID, ProductOptionModel option);
        void UpdateOption(Guid optionID, ProductOptionModel option);
        void DeleteOption(Guid optionID);
    }
}
