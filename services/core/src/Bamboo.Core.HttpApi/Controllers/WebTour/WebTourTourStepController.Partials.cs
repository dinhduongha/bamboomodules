using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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