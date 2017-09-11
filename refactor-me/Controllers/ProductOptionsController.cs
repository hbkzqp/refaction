using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Filters;
using refactor_me.ViewModel;
using System;
using System.Web.Http;
//using refactor_me.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products/{productId}/options")]
    [ModelVaild]
    public class ProductOptionsController : ApiController
    {
        private IProductOptionService _productOptionservice;
        public ProductOptionsController(IProductOptionService service)
        {
            _productOptionservice = service;
        }
        [Route("")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return new ProductOptions() { Items = _productOptionservice.GetOptionsByProductID(productId) } ;
        }

        [Route("{optionId}")]
        [HttpGet]
        public ProductOptionModel GetOption(Guid productId, Guid optionId)
        {
            return _productOptionservice.GetExactOption(productId, optionId);
        }

        [Route("")]
        [HttpPost]
        public void CreateOption(Guid productId, [FromBody]ProductOptionModel option)
        {
            _productOptionservice.AddOption(productId, option);
        }

        [Route("{optionId}")]
        [HttpPut]
        public void UpdateOption(Guid optionId, [FromBody]ProductOptionModel option)
        {
            _productOptionservice.UpdateOption(optionId, option);
        }

        [Route("{optionId}")]
        [HttpDelete]
        public void DeleteOption(Guid optionId)
        {
            _productOptionservice.DeleteOption(optionId);
        }
    }
}
