using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Filters;
using refactor_me.ViewModel;
using System;
using System.Threading.Tasks;
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
        public async Task CreateOption(Guid productId, [FromBody]ProductOptionModel option)
        {
            await _productOptionservice.AddOption(productId, option);
        }

        [Route("{optionId}")]
        [HttpPut]
        public async Task UpdateOption(Guid optionId, [FromBody]ProductOptionModel option)
        {
            await _productOptionservice.UpdateOption(optionId, option);
        }

        [Route("{optionId}")]
        [HttpDelete]
        public async Task DeleteOption(Guid optionId)
        {
            await _productOptionservice.DeleteOption(optionId);
        }
    }
}
