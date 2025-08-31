using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailGatewayAllowedController
    {
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] MailGatewayAllowedGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input.HelpMessage);
            return Ok(result);
        }
    }
}