using ProductServices.Models;
using System.Collections.Generic;

namespace refactor_me.ViewModel
{
    public class Products
    {
        public IEnumerable<ProductModel> Items { get; set; }
    }
}
