using ProductServices.Interface;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
//using refactor_me.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductOptionsController : ApiController
    {
        private IProductOptionService _productOptionService;
        public ProductOptionsController(IProductOptionService service)
        {
            this._productOptionService = service;
        }
        [Route("{productId}/options")]
        [HttpGet]
        public IEnumerable<ProductOptionModel>  GetOptions(Guid productId)
        {
            return this._productOptionService.GetOptionsByProductID(productId);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOptionModel GetOption(Guid productId, Guid id)
        {
            return this._productOptionService.GetExactOption(productId, id);
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOptionModel option)
        {
            this._productOptionService.AddOption(productId, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOptionModel option)
        {
            this._productOptionService.UpdateOption(id, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            this._productOptionService.DeleteOption(id);
        }
    }
}
