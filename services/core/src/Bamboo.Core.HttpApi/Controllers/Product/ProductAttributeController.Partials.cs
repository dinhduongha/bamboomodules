using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductAttributeController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-product-template-attribute-lines")]
        public async Task<IActionResult> ActionOpenProductTemplateAttributeLinesAsync(Guid id)
        {
            var result = await _appService.OpenProductTemplateAttributeLinesAsync(id);
            return Ok(result);
        }
    }
}