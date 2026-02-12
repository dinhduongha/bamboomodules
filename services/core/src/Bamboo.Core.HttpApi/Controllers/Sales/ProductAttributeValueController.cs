using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/sales/ProductAttributeValue")]
    public partial class ProductAttributeValueController : AbpController
    {
        protected readonly IProductAttributeValueAppService _appService;
        public ProductAttributeValueController(IProductAttributeValueAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-to-products")]
        public async Task<IActionResult> AddToProductsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToProductsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-prices")]
        public async Task<IActionResult> UpdatePricesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdatePricesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-is-used-on-products")]
        public async Task<IActionResult> CheckIsUsedOnProductsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckIsUsedOnProductsAsync(ids);
            return Ok(result);
        }
    }
    
}