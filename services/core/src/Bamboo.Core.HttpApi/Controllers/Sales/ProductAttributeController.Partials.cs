using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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