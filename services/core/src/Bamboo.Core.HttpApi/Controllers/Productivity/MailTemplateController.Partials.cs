using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailTemplateController
    {
        
        [HttpPost]
        [Route("action-open-mail-preview")]
        public async Task<IActionResult> ActionOpenMailPreviewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenMailPreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(MailTemplateCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-action")]
        public async Task<IActionResult> CreateActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-mail")]
        public async Task<IActionResult> SendMailAsync(MailTemplateSendMailRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendMailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-mail-batch")]
        public async Task<IActionResult> SendMailBatchAsync(MailTemplateSendMailBatchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendMailBatchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkActionAsync(ids);
            return Ok(result);
        }
    }
}