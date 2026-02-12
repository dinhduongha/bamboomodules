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
    [Route("api/v1/technical-settings/CloudStorageMigrationReport")]
    public partial class CloudStorageMigrationReportController : AbpController
    {
        protected readonly ICloudStorageMigrationReportAppService _appService;
        public CloudStorageMigrationReportController(ICloudStorageMigrationReportAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-progress")]
        public async Task<IActionResult> GetProgressAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetProgressAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}