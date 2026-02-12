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
    [Route("api/v1/productivity/DataRecycleModel")]
    public partial class DataRecycleModelController : AbpController
    {
        protected readonly IDataRecycleModelAppService _appService;
        public DataRecycleModelController(IDataRecycleModelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-recycle-records")]
        public async Task<IActionResult> RecycleRecordsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RecycleRecordsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-records")]
        public async Task<IActionResult> OpenRecordsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRecordsAsync(ids);
            return Ok(result);
        }
    }
    
}