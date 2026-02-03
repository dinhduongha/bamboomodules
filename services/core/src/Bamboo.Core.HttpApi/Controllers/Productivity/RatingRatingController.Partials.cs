using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RatingRatingController
    {
        
        [HttpPost]
        [Route("action-open-rated-object")]
        public async Task<IActionResult> ActionOpenRatedObjectAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRatedObjectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> ResetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
    }
}