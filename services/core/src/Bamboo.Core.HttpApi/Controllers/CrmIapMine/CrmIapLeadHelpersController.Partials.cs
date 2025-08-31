using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
{
    public partial class CrmIapLeadHelpersController
    {
        
        [HttpPost]
        [Route("{id}/lead-vals-from-response")]
        public async Task<IActionResult> LeadValsFromResponseAsync(Guid id, [FromBody] CrmIapLeadHelpersLeadValsFromResponseRequestDto input)
        {
            var result = await _appService.LeadValsFromResponseAsync(id, input.LeadType, input.TeamId, input.TagIds, input.UserId, input.CompanyData, input.PeopleData);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/notify-no-more-credit")]
        public async Task<IActionResult> NotifyNoMoreCreditAsync(Guid id, [FromBody] CrmIapLeadHelpersNotifyNoMoreCreditRequestDto input)
        {
            var result = await _appService.NotifyNoMoreCreditAsync(id, input.ServiceName, input.ModelName, input.NotificationParameter);
            return Ok(result);
        }
    }
}