using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    public partial class MrpBomLineController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-attachments")]
        public async Task<IActionResult> ActionSeeAttachmentsAsync(Guid id)
        {
            var result = await _appService.SeeAttachmentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-uom-id")]
        public async Task<IActionResult> OnchangeProductUomIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductUomIdAsync(id);
            return Ok(result);
        }
    }
}