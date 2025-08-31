using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailTemplateController
    {
        
        [HttpPost]
        [Route("{id}/cancel-unlink")]
        public async Task<IActionResult> CancelUnlinkAsync(Guid id)
        {
            var result = await _appService.CancelUnlinkAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] MailTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-action")]
        public async Task<IActionResult> CreateActionAsync(Guid id)
        {
            var result = await _appService.CreateActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-delete-confirmation-modal")]
        public async Task<IActionResult> OpenDeleteConfirmationModalAsync(Guid id)
        {
            var result = await _appService.OpenDeleteConfirmationModalAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-mail")]
        public async Task<IActionResult> SendMailAsync(Guid id, [FromBody] MailTemplateSendMailRequestDto input)
        {
            var result = await _appService.SendMailAsync(id, input.ResId, input.ForceSend, input.RaiseException, input.EmailValues, input.EmailLayoutXmlid);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-mail-batch")]
        public async Task<IActionResult> SendMailBatchAsync(Guid id, [FromBody] MailTemplateSendMailBatchRequestDto input)
        {
            var result = await _appService.SendMailBatchAsync(id, input.ResIds, input.ForceSend, input.RaiseException, input.EmailValues, input.EmailLayoutXmlid);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync(Guid id)
        {
            var result = await _appService.UnlinkActionAsync(id);
            return Ok(result);
        }
    }
}