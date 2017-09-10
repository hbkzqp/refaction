using System;
using System.Web.Http;
using System.Web.Routing;
using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Filters;
using refactor_me.ViewModel;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    [ModelVaild]
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService service)
        {
            this._productService = service;
        }
        [Route("")]
        [HttpGet]
        public Products GetAll()
        {
            return new Products() { Items = this._productService.GetAllProduct() }; ;
        }

        [Route("")]
        [HttpGet]
        public ProductModel SearchByName(string name)
        {
            return this._productService.FindProductByName(name);
        }

        [Route("{id}")]
        [HttpGet]
        public ProductModel GetProduct(Guid id)
        {
            return this._productService.FindProductByID(id);
        }

        [Route("")]
        [HttpPost]
        public void Create([FromBody]ProductModel product)
        {
            this._productService.AddProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, [FromBody]ProductModel product)
        {
            this._productService.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this._productService.DeleteProduct(id);
        }
    }
}
