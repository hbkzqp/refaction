using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Interface
{
    interface IProductOptionService
    {
        IEnumerable<ProductOption> GetOptionsByProductID(Guid optionID);
        ProductOption GetExactOption(Guid productID, Guid optionID);
        void AddOption(Guid productID, ProductOption option);
        void UpdateOption(Guid optionID, ProductOption option);
        void DeleteOption(Guid optionID);
    }
}
