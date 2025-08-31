using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    public partial class ResourceResourceController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResourceResourceCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(Guid id, [FromBody] ResourceResourceGetAvatarCardDataRequestDto input)
        {
            var result = await _appService.GetAvatarCardDataAsync(id, input.Fields);
            return Ok(result);
        }
    }
}