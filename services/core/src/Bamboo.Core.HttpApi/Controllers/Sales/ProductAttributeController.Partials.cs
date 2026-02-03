using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductAttributeController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-product-template-attribute-lines")]
        public async Task<IActionResult> ActionOpenProductTemplateAttributeLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProductTemplateAttributeLinesAsync(ids);
            return Ok(result);
        }
    }
}