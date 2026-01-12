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