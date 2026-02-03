using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductSupplierinfoController
    {
        
        [HttpPost]
        [Route("action-set-supplier")]
        public async Task<IActionResult> ActionSetSupplierAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetSupplierAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
    }
}