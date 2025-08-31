using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResUsersIdentitycheckController
    {
        
        [HttpPost]
        [Route("{id}/action-use-password")]
        public async Task<IActionResult> ActionUsePasswordAsync(Guid id)
        {
            var result = await _appService.UsePasswordAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run-check")]
        public async Task<IActionResult> RunCheckAsync(Guid id)
        {
            var result = await _appService.RunCheckAsync(id);
            return Ok(result);
        }
    }
}