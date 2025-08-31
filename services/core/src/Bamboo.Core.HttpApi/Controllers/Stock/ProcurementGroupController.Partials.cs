using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class ProcurementGroupController
    {
        
        [HttpPost]
        [Route("{id}/run")]
        public async Task<IActionResult> RunAsync(Guid id, [FromBody] ProcurementGroupRunRequestDto input)
        {
            var result = await _appService.RunAsync(id, input.Procurements, input.RaiseUserError);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(Guid id, [FromBody] ProcurementGroupRunSchedulerRequestDto input)
        {
            var result = await _appService.RunSchedulerAsync(id, input.UseNewCursor, input.CompanyId);
            return Ok(result);
        }
    }
}