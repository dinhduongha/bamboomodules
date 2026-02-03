using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAssetDepreciationLineController
    {
        
        [HttpPost]
        [Route("create-grouped-move")]
        public async Task<IActionResult> CreateGroupedMoveAsync(AccountAssetDepreciationLineCreateGroupedMoveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateGroupedMoveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-move")]
        public async Task<IActionResult> CreateMoveAsync(AccountAssetDepreciationLineCreateMoveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateMoveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-message-when-posted")]
        public async Task<IActionResult> LogMessageWhenPostedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LogMessageWhenPostedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-lines-and-close-asset")]
        public async Task<IActionResult> PostLinesAndCloseAssetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostLinesAndCloseAssetAsync(ids);
            return Ok(result);
        }
    }
}