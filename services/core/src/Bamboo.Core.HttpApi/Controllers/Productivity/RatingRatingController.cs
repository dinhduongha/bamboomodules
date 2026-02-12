using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/RatingRating")]
    public partial class RatingRatingController : AbpController
    {
        protected readonly IRatingRatingAppService _appService;
        public RatingRatingController(IRatingRatingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-rated-object")]
        public async Task<IActionResult> OpenRatedObjectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRatedObjectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> ResetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
    }
    
}