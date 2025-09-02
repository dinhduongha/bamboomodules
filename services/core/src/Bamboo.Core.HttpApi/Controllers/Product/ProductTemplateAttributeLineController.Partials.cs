using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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