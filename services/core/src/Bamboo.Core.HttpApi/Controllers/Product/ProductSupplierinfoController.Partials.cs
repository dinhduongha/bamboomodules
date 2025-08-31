using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductSupplierinfoController
    {
        
        [HttpPost]
        [Route("{id}/action-set-supplier")]
        public async Task<IActionResult> ActionSetSupplierAsync(Guid id)
        {
            var result = await _appService.SetSupplierAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
    }
}