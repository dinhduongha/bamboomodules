using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    public partial class ResourceResourceController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResourceResourceCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(Guid id, [FromBody] ResourceResourceGetAvatarCardDataRequestDto input)
        {
            var result = await _appService.GetAvatarCardDataAsync(id, input);
            return Ok(result);
        }
    }
}