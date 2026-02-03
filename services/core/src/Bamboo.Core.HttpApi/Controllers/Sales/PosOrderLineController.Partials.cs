using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosOrderLineController
    {
        
        [HttpPost]
        [Route("get-existing-lots")]
        public async Task<IActionResult> GetExistingLotsAsync(PosOrderLineGetExistingLotsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetExistingLotsAsync(input);
            return Ok(result);
        }
    }
}