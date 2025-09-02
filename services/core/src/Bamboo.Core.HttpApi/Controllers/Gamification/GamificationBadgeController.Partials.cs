using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    public partial class GamificationBadgeController
    {
        
        [HttpPost]
        [Route("{id}/check-granting")]
        public async Task<IActionResult> CheckGrantingAsync(Guid id)
        {
            var result = await _appService.CheckGrantingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-granted-employees")]
        public async Task<IActionResult> GetGrantedEmployeesAsync(Guid id)
        {
            var result = await _appService.GetGrantedEmployeesAsync(id);
            return Ok(result);
        }
    }
}