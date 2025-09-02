using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrProfileController
    {
        
        [HttpPost]
        [Route("{id}/set-profiling")]
        public async Task<IActionResult> SetProfilingAsync(Guid id, [FromBody] IrProfileSetProfilingRequestDto input)
        {
            var result = await _appService.SetProfilingAsync(id, input);
            return Ok(result);
        }
    }
}