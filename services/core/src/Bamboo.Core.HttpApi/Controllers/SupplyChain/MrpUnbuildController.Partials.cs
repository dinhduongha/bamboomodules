using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpUnbuildController
    {
        
        [HttpPost]
        [Route("action-unbuild")]
        public async Task<IActionResult> ActionUnbuildAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnbuildAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
    }
}