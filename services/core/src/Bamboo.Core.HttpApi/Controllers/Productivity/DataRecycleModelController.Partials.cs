using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    public partial class DataRecycleModelController
    {
        
        [HttpPost]
        [Route("{id}/action-recycle-records")]
        public async Task<IActionResult> ActionRecycleRecordsAsync(Guid id)
        {
            var result = await _appService.RecycleRecordsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-records")]
        public async Task<IActionResult> OpenRecordsAsync(Guid id)
        {
            var result = await _appService.OpenRecordsAsync(id);
            return Ok(result);
        }
    }
}