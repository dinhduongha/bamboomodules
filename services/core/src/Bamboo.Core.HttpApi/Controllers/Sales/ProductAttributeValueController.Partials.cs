using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductAttributeValueController
    {
        
        [HttpPost]
        [Route("{id}/action-add-to-products")]
        public async Task<IActionResult> ActionAddToProductsAsync(Guid id)
        {
            var result = await _appService.AddToProductsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-prices")]
        public async Task<IActionResult> ActionUpdatePricesAsync(Guid id)
        {
            var result = await _appService.UpdatePricesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-is-used-on-products")]
        public async Task<IActionResult> CheckIsUsedOnProductsAsync(Guid id)
        {
            var result = await _appService.CheckIsUsedOnProductsAsync(id);
            return Ok(result);
        }
    }
}