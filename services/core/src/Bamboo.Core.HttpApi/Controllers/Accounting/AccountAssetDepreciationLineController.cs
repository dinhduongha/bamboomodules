using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountAssetDepreciationLine")]
    public partial class AccountAssetDepreciationLineController : AbpController
    {
        protected readonly IAccountAssetDepreciationLineAppService _appService;
        public AccountAssetDepreciationLineController(IAccountAssetDepreciationLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("create-grouped-move")]
        public async Task<IActionResult> CreateGroupedMoveAsync([FromBody] AccountAssetDepreciationLineCreateGroupedMoveRequestDto input)
        {
            var result = await _appService.CreateGroupedMoveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-move")]
        public async Task<IActionResult> CreateMoveAsync([FromBody] AccountAssetDepreciationLineCreateMoveRequestDto input)
        {
            var result = await _appService.CreateMoveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-message-when-posted")]
        public async Task<IActionResult> LogMessageWhenPostedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LogMessageWhenPostedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-lines-and-close-asset")]
        public async Task<IActionResult> PostLinesAndCloseAssetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostLinesAndCloseAssetAsync(ids);
            return Ok(result);
        }
    }
    
}