using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrProfileController
    {
        
        [HttpPost]
        [Route("{id}/set-profiling")]
        public async Task<IActionResult> SetProfilingAsync(Guid id, [FromBody] IrProfileSetProfilingRequestDto input)
        {
            var result = await _appService.SetProfilingAsync(id, input.Profile, input.Collectors, input.Params);
            return Ok(result);
        }
    }
}