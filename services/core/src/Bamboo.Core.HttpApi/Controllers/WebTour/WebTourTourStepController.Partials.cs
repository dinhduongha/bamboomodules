using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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