using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
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