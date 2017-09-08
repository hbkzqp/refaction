using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using ProductServices.Interface;
using ProductCore.Abstraction.Interface.Mappers;
using ProductServices.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService service)
        {
            this._productService = service;
        }
        [Route]
        [HttpGet]
        public IEnumerable<ProductModel> GetAll()
        {
            return this._productService.GetAllProduct();
        }

        [Route]
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

        [Route]
        [HttpPost]
        public void Create(ProductModel product)
        {
            this._productService.AddProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, ProductModel product)
        {
            this._productService.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this._productService.DeleteProuct(id);
        }
    }
}
