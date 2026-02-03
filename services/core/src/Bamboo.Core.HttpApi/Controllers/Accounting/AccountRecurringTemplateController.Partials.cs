using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountRecurringTemplateController
    {
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
    }
}