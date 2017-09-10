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
        private IProductOptionService _productOptionService;
        public ProductOptionsController(IProductOptionService service)
        {
            this._productOptionService = service;
        }
        [Route("")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return new ProductOptions() { Items = this._productOptionService.GetOptionsByProductID(productId) } ;
        }

        [Route("{optionId}")]
        [HttpGet]
        public ProductOptionModel GetOption(Guid productId, Guid optionId)
        {
            return this._productOptionService.GetExactOption(productId, optionId);
        }

        [Route("")]
        [HttpPost]
        public void CreateOption(Guid productId, [FromBody]ProductOptionModel option)
        {
            this._productOptionService.AddOption(productId, option);
        }

        [Route("{optionId}")]
        [HttpPut]
        public void UpdateOption(Guid optionId, [FromBody]ProductOptionModel option)
        {
            this._productOptionService.UpdateOption(optionId, option);
        }

        [Route("{optionId}")]
        [HttpDelete]
        public void DeleteOption(Guid optionId)
        {
            this._productOptionService.DeleteOption(optionId);
        }
    }
}
