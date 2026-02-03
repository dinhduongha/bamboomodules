using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductAttributeValueController
    {
        
        [HttpPost]
        [Route("action-add-to-products")]
        public async Task<IActionResult> ActionAddToProductsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToProductsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-prices")]
        public async Task<IActionResult> ActionUpdatePricesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdatePricesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-is-used-on-products")]
        public async Task<IActionResult> CheckIsUsedOnProductsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckIsUsedOnProductsAsync(ids);
            return Ok(result);
        }
    }
}