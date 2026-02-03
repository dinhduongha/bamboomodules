using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResGroupsController
    {
        
        [HttpPost]
        [Route("action-show-all-users")]
        public async Task<IActionResult> ActionShowAllUsersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowAllUsersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ResGroupsCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-application-groups")]
        public async Task<IActionResult> GetApplicationGroupsAsync(ResGroupsGetApplicationGroupsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetApplicationGroupsAsync(input);
            return Ok(result);
        }
    }
}