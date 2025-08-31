using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    public partial class ForumPostController
    {
        
        [HttpPost]
        [Route("{id}/close")]
        public async Task<IActionResult> CloseAsync(Guid id, [FromBody] ForumPostCloseRequestDto input)
        {
            var result = await _appService.CloseAsync(id, input.ReasonId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/convert-answer-to-comment")]
        public async Task<IActionResult> ConvertAnswerToCommentAsync(Guid id)
        {
            var result = await _appService.ConvertAnswerToCommentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/convert-comment-to-answer")]
        public async Task<IActionResult> ConvertCommentToAnswerAsync(Guid id, [FromBody] ForumPostConvertCommentToAnswerRequestDto input)
        {
            var result = await _appService.ConvertCommentToAnswerAsync(id, input.MessageId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync(Guid id)
        {
            var result = await _appService.GoToWebsiteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mark-as-offensive-batch")]
        public async Task<IActionResult> MarkAsOffensiveBatchAsync(Guid id, [FromBody] ForumPostMarkAsOffensiveBatchRequestDto input)
        {
            var result = await _appService.MarkAsOffensiveBatchAsync(id, input.Key, input.Values);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id)
        {
            var result = await _appService.MessagePostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reopen")]
        public async Task<IActionResult> ReopenAsync(Guid id)
        {
            var result = await _appService.ReopenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-comment")]
        public async Task<IActionResult> UnlinkCommentAsync(Guid id, [FromBody] ForumPostUnlinkCommentRequestDto input)
        {
            var result = await _appService.UnlinkCommentAsync(id, input.MessageId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate")]
        public async Task<IActionResult> ValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/vote")]
        public async Task<IActionResult> VoteAsync(Guid id, [FromBody] ForumPostVoteRequestDto input)
        {
            var result = await _appService.VoteAsync(id, input.Upvote);
            return Ok(result);
        }
    }
}