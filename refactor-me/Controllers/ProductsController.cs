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

        public ProductsController()
        {
            
        }
        public ProductsController(IProductService service)
        {
            this._productService = service;
        }
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(this._productService.GetAllProduct());
        }

        [Route("SearchByName")]
        [HttpGet]
        public ProductModel SearchByName(string name)
        {
            return this._productService.FindProductByName(name);
        }

        [Route("GetProduct/{id}")]
        [HttpGet]
        public ProductModel GetProduct(Guid id)
        {
            return this._productService.FindProductByID(id);
        }

        [Route("CreateProduct")]
        [HttpPost]
        public void Create([FromBody]ProductModel product)
        {
            if (ModelState.IsValid)
            {
                
            }
            this._productService.AddProduct(product);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPut]
        public void Update(Guid id, [FromBody]ProductModel product)
        {
            this._productService.UpdateProduct(id, product);
        }

        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this._productService.DeleteProduct(id);
        }
    }
}
