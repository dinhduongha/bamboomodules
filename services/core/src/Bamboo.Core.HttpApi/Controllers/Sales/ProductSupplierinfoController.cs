using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/sales/ProductSupplierinfo")]
    public partial class ProductSupplierinfoController : AbpController
    {
        protected readonly IProductSupplierinfoAppService _appService;
        public ProductSupplierinfoController(IProductSupplierinfoAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-set-supplier")]
        public async Task<IActionResult> SetSupplierAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetSupplierAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
    }
    
}