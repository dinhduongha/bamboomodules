using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ForumPostController
    {
        
        [HttpPost]
        [Route("close")]
        public async Task<IActionResult> CloseAsync(ForumPostCloseRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CloseAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-answer-to-comment")]
        public async Task<IActionResult> ConvertAnswerToCommentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConvertAnswerToCommentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-comment-to-answer")]
        public async Task<IActionResult> ConvertCommentToAnswerAsync(ForumPostConvertCommentToAnswerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConvertCommentToAnswerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-as-offensive-batch")]
        public async Task<IActionResult> MarkAsOffensiveBatchAsync(ForumPostMarkAsOffensiveBatchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MarkAsOffensiveBatchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reopen")]
        public async Task<IActionResult> ReopenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReopenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-comment")]
        public async Task<IActionResult> UnlinkCommentAsync(ForumPostUnlinkCommentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UnlinkCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> ValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> VoteAsync(ForumPostVoteRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.VoteAsync(input);
            return Ok(result);
        }
    }
}