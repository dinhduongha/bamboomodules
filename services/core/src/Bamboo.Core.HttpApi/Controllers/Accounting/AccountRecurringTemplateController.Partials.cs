using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountRecurringTemplateController
    {
        
        [HttpPost]
        [Route("{id}/action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid id)
        {
            var result = await _appService.DoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid id)
        {
            var result = await _appService.DraftAsync(id);
            return Ok(result);
        }
    }
}