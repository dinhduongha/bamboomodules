using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrLeaveAccrualLevelController
    {
        
        [HttpPost]
        [Route("{id}/action-save-new")]
        public async Task<IActionResult> ActionSaveNewAsync(Guid id)
        {
            var result = await _appService.SaveNewAsync(id);
            return Ok(result);
        }
    }
}