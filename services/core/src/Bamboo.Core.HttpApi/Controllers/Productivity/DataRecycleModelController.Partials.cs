using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DataRecycleModelController
    {
        
        [HttpPost]
        [Route("action-recycle-records")]
        public async Task<IActionResult> ActionRecycleRecordsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RecycleRecordsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-records")]
        public async Task<IActionResult> OpenRecordsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRecordsAsync(ids);
            return Ok(result);
        }
    }
}