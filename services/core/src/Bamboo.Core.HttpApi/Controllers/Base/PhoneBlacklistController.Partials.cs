using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.PhoneValidation
{
    public partial class PhoneBlacklistController
    {
        
        [HttpPost]
        [Route("{id}/action-add")]
        public async Task<IActionResult> ActionAddAsync(Guid id)
        {
            var result = await _appService.AddAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add")]
        public async Task<IActionResult> AddAsync(Guid id, [FromBody] PhoneBlacklistAddRequestDto input)
        {
            var result = await _appService.AddAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/phone-action-blacklist-remove")]
        public async Task<IActionResult> PhoneActionBlacklistRemoveAsync(Guid id)
        {
            var result = await _appService.PhoneBlacklistRemoveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove")]
        public async Task<IActionResult> RemoveAsync(Guid id, [FromBody] PhoneBlacklistRemoveRequestDto input)
        {
            var result = await _appService.RemoveAsync(id, input);
            return Ok(result);
        }
    }
}