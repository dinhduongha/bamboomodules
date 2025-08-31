using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    public partial class AccountAssetDepreciationLineController
    {
        
        [HttpPost]
        [Route("{id}/create-grouped-move")]
        public async Task<IActionResult> CreateGroupedMoveAsync(Guid id, [FromBody] AccountAssetDepreciationLineCreateGroupedMoveRequestDto input)
        {
            var result = await _appService.CreateGroupedMoveAsync(id, input.PostMove);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-move")]
        public async Task<IActionResult> CreateMoveAsync(Guid id, [FromBody] AccountAssetDepreciationLineCreateMoveRequestDto input)
        {
            var result = await _appService.CreateMoveAsync(id, input.PostMove);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/log-message-when-posted")]
        public async Task<IActionResult> LogMessageWhenPostedAsync(Guid id)
        {
            var result = await _appService.LogMessageWhenPostedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/post-lines-and-close-asset")]
        public async Task<IActionResult> PostLinesAndCloseAssetAsync(Guid id)
        {
            var result = await _appService.PostLinesAndCloseAssetAsync(id);
            return Ok(result);
        }
    }
}