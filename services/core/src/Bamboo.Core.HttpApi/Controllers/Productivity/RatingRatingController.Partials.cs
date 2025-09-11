using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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