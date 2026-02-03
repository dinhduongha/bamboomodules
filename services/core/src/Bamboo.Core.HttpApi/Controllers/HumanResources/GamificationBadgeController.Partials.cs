using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class GamificationBadgeController
    {
        
        [HttpPost]
        [Route("check-granting")]
        public async Task<IActionResult> CheckGrantingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckGrantingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-granted-employees")]
        public async Task<IActionResult> GetGrantedEmployeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetGrantedEmployeesAsync(ids);
            return Ok(result);
        }
    }
}