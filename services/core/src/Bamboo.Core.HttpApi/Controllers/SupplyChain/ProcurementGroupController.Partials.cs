using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProcurementGroupController
    {
        
        [HttpPost]
        [Route("{id}/run")]
        public async Task<IActionResult> RunAsync(Guid id, [FromBody] ProcurementGroupRunRequestDto input)
        {
            var result = await _appService.RunAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(Guid id, [FromBody] ProcurementGroupRunSchedulerRequestDto input)
        {
            var result = await _appService.RunSchedulerAsync(id, input);
            return Ok(result);
        }
    }
}