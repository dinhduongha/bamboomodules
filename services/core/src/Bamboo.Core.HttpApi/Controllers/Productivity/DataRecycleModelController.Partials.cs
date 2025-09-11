using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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