using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebTourTourStepController
    {
        
        [HttpPost]
        [Route("{id}/get-steps-json")]
        public async Task<IActionResult> GetStepsJsonAsync(Guid id)
        {
            var result = await _appService.GetStepsJsonAsync(id);
            return Ok(result);
        }
    }
}