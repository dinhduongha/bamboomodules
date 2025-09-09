using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Stock
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