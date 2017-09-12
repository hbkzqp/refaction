using System;
using System.Web.Http;
using System.Web.Routing;
using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Filters;
using refactor_me.ViewModel;
using System.Threading.Tasks;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    [ModelVaild]
    public class ProductsController : ApiController
    {
        private IProductService _productservice;

        public ProductsController(IProductService service)
        {
            _productservice = service;
        }
        [Route("")]
        [HttpGet]
        public Products GetAll()
        {
            return new Products() { Items = _productservice.GetAllProduct() }; ;
        }

        [Route("")]
        [HttpGet]
        public ProductModel SearchByName(string name)
        {
            return _productservice.FindProductByName(name);
        }

        [Route("{id}")]
        [HttpGet]
        public ProductModel GetProduct(Guid id)
        {
            return _productservice.FindProductByID(id);
        }

        [Route("")]
        [HttpPost]
        public async Task Create([FromBody]ProductModel product)
        {
             await _productservice.AddProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task Update(Guid id, [FromBody]ProductModel product)
        {
            await _productservice.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _productservice.DeleteProduct(id);
        }
    }
}
