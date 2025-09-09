using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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