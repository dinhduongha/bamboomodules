using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PhoneBlacklistController
    {
        
        [HttpPost]
        [Route("action-add")]
        public async Task<IActionResult> ActionAddAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(PhoneBlacklistAddRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("phone-action-blacklist-remove")]
        public async Task<IActionResult> PhoneActionBlacklistRemoveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PhoneBlacklistRemoveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveAsync(PhoneBlacklistRemoveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RemoveAsync(input);
            return Ok(result);
        }
    }
}