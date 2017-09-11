﻿using System;
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
        public void Create([FromBody]ProductModel product)
        {
            _productservice.AddProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, [FromBody]ProductModel product)
        {
            _productservice.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _productservice.DeleteProduct(id);
        }
    }
}
