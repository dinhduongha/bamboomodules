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
    [Route("api/v1/website/ForumPost")]
    public partial class ForumPostController : AbpController
    {
        protected readonly IForumPostAppService _appService;
        public ForumPostController(IForumPostAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("close")]
        public async Task<IActionResult> CloseAsync([FromBody] ForumPostCloseRequestDto input)
        {
            var result = await _appService.CloseAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-answer-to-comment")]
        public async Task<IActionResult> ConvertAnswerToCommentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConvertAnswerToCommentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-comment-to-answer")]
        public async Task<IActionResult> ConvertCommentToAnswerAsync([FromBody] ForumPostConvertCommentToAnswerRequestDto input)
        {
            var result = await _appService.ConvertCommentToAnswerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-as-offensive-batch")]
        public async Task<IActionResult> MarkAsOffensiveBatchAsync([FromBody] ForumPostMarkAsOffensiveBatchRequestDto input)
        {
            var result = await _appService.MarkAsOffensiveBatchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reopen")]
        public async Task<IActionResult> ReopenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReopenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-comment")]
        public async Task<IActionResult> UnlinkCommentAsync([FromBody] ForumPostUnlinkCommentRequestDto input)
        {
            var result = await _appService.UnlinkCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> VoteAsync([FromBody] ForumPostVoteRequestDto input)
        {
            var result = await _appService.VoteAsync(input);
            return Ok(result);
        }
    }
    
}