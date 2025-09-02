using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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