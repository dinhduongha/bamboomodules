using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResGroupsController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResGroupsCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-application-groups")]
        public async Task<IActionResult> GetApplicationGroupsAsync(Guid id, [FromBody] ResGroupsGetApplicationGroupsRequestDto input)
        {
            var result = await _appService.GetApplicationGroupsAsync(id, input.Domain);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-groups-by-application")]
        public async Task<IActionResult> GetGroupsByApplicationAsync(Guid id)
        {
            var result = await _appService.GetGroupsByApplicationAsync(id);
            return Ok(result);
        }
    }
}