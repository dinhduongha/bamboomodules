using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpBomLineController
    {
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-attachments")]
        public async Task<IActionResult> ActionSeeAttachmentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeAttachmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeProductIdAsync(ids);
            return Ok(result);
        }
    }
}