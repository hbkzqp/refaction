using ProductServices.Models;
using System.Collections.Generic;

namespace refactor_me.ViewModel
{
    public class ProductOptions
    {
        public IEnumerable<ProductOptionModel> Items { get; set; }
    }
}
