using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailMessageController
    {
        
        [HttpPost]
        [Route("{id}/action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid id)
        {
            var result = await _appService.OpenDocumentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel-letter")]
        public async Task<IActionResult> CancelLetterAsync(Guid id)
        {
            var result = await _appService.CancelLetterAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/export-data")]
        public async Task<IActionResult> ExportDataAsync(Guid id, [FromBody] MailMessageExportDataRequestDto input)
        {
            var result = await _appService.ExportDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fetch")]
        public async Task<IActionResult> FetchAsync(Guid id, [FromBody] MailMessageFetchRequestDto input)
        {
            var result = await _appService.FetchAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-thread-message")]
        public async Task<IActionResult> IsThreadMessageAsync(Guid id, [FromBody] MailMessageIsThreadMessageRequestDto input)
        {
            var result = await _appService.IsThreadMessageAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsReadAsync(Guid id, [FromBody] MailMessageMarkAllAsReadRequestDto input)
        {
            var result = await _appService.MarkAllAsReadAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/portal-message-format")]
        public async Task<IActionResult> PortalMessageFormatAsync(Guid id, [FromBody] MailMessagePortalMessageFormatRequestDto input)
        {
            var result = await _appService.PortalMessageFormatAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-letter")]
        public async Task<IActionResult> SendLetterAsync(Guid id)
        {
            var result = await _appService.SendLetterAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-message-done")]
        public async Task<IActionResult> SetMessageDoneAsync(Guid id)
        {
            var result = await _appService.SetMessageDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-message-starred")]
        public async Task<IActionResult> ToggleMessageStarredAsync(Guid id)
        {
            var result = await _appService.ToggleMessageStarredAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unstar-all")]
        public async Task<IActionResult> UnstarAllAsync(Guid id)
        {
            var result = await _appService.UnstarAllAsync(id);
            return Ok(result);
        }
    }
}