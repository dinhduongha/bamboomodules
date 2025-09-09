using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebTour
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