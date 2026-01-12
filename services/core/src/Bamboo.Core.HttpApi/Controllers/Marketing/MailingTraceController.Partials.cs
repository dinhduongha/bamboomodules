using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingTraceController
    {
        
        [HttpPost]
        [Route("{id}/action-view-contact")]
        public async Task<IActionResult> ActionViewContactAsync(Guid id)
        {
            var result = await _appService.ViewContactAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-bounced")]
        public async Task<IActionResult> SetBouncedAsync(Guid id, [FromBody] MailingTraceSetBouncedRequestDto input)
        {
            var result = await _appService.SetBouncedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-canceled")]
        public async Task<IActionResult> SetCanceledAsync(Guid id, [FromBody] MailingTraceSetCanceledRequestDto input)
        {
            var result = await _appService.SetCanceledAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-clicked")]
        public async Task<IActionResult> SetClickedAsync(Guid id, [FromBody] MailingTraceSetClickedRequestDto input)
        {
            var result = await _appService.SetClickedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-failed")]
        public async Task<IActionResult> SetFailedAsync(Guid id, [FromBody] MailingTraceSetFailedRequestDto input)
        {
            var result = await _appService.SetFailedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-opened")]
        public async Task<IActionResult> SetOpenedAsync(Guid id, [FromBody] MailingTraceSetOpenedRequestDto input)
        {
            var result = await _appService.SetOpenedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-replied")]
        public async Task<IActionResult> SetRepliedAsync(Guid id, [FromBody] MailingTraceSetRepliedRequestDto input)
        {
            var result = await _appService.SetRepliedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-sent")]
        public async Task<IActionResult> SetSentAsync(Guid id, [FromBody] MailingTraceSetSentRequestDto input)
        {
            var result = await _appService.SetSentAsync(id, input);
            return Ok(result);
        }
    }
}