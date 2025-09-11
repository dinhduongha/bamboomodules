using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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