using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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