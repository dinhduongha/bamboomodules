using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResUsersApikeysDescriptionController
    {
        
        [HttpPost]
        [Route("check-access-make-key")]
        public async Task<IActionResult> CheckAccessMakeKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckAccessMakeKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("make-key")]
        public async Task<IActionResult> MakeKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MakeKeyAsync(ids);
            return Ok(result);
        }
    }
}