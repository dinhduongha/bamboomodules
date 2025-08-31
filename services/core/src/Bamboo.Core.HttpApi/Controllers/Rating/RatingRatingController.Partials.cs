using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Rating
{
    public partial class RatingRatingController
    {
        
        [HttpPost]
        [Route("{id}/action-open-rated-object")]
        public async Task<IActionResult> ActionOpenRatedObjectAsync(Guid id)
        {
            var result = await _appService.OpenRatedObjectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset")]
        public async Task<IActionResult> ResetAsync(Guid id)
        {
            var result = await _appService.ResetAsync(id);
            return Ok(result);
        }
    }
}