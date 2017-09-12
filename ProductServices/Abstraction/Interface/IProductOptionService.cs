using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Interface
{
    public interface IProductOptionService
    {
        IEnumerable<ProductOptionModel> GetOptionsByProductID(Guid productID);
        ProductOptionModel GetExactOption(Guid productID, Guid optionID);
        Task AddOption(Guid productID, ProductOptionModel option);
        Task UpdateOption(Guid optionID, ProductOptionModel option);
        Task DeleteOption(Guid optionID);
    }
}
