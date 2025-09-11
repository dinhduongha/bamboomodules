using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmIapLeadHelpersController
    {
        
        [HttpPost]
        [Route("{id}/lead-vals-from-response")]
        public async Task<IActionResult> LeadValsFromResponseAsync(Guid id, [FromBody] CrmIapLeadHelpersLeadValsFromResponseRequestDto input)
        {
            var result = await _appService.LeadValsFromResponseAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/notify-no-more-credit")]
        public async Task<IActionResult> NotifyNoMoreCreditAsync(Guid id, [FromBody] CrmIapLeadHelpersNotifyNoMoreCreditRequestDto input)
        {
            var result = await _appService.NotifyNoMoreCreditAsync(id, input);
            return Ok(result);
        }
    }
}