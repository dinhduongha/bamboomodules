using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailMessageController
    {
        
        [HttpPost]
        [Route("action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel-letter")]
        public async Task<IActionResult> CancelLetterAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelLetterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("export-data")]
        public async Task<IActionResult> ExportDataAsync(MailMessageExportDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExportDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fetch")]
        public async Task<IActionResult> FetchAsync(MailMessageFetchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FetchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsReadAsync(MailMessageMarkAllAsReadRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MarkAllAsReadAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("portal-message-format")]
        public async Task<IActionResult> PortalMessageFormatAsync(MailMessagePortalMessageFormatRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PortalMessageFormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-letter")]
        public async Task<IActionResult> SendLetterAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendLetterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-message-done")]
        public async Task<IActionResult> SetMessageDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetMessageDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-message-starred")]
        public async Task<IActionResult> ToggleMessageStarredAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleMessageStarredAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unstar-all")]
        public async Task<IActionResult> UnstarAllAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnstarAllAsync(ids);
            return Ok(result);
        }
    }
}