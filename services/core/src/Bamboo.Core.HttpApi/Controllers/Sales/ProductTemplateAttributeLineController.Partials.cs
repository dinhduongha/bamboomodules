using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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