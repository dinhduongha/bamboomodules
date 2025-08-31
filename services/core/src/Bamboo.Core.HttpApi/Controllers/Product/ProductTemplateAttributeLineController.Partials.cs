using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductTemplateAttributeLineController
    {
        
        [HttpPost]
        [Route("{id}/action-open-attribute-values")]
        public async Task<IActionResult> ActionOpenAttributeValuesAsync(Guid id)
        {
            var result = await _appService.OpenAttributeValuesAsync(id);
            return Ok(result);
        }
    }
}