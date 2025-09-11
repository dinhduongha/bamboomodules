using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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