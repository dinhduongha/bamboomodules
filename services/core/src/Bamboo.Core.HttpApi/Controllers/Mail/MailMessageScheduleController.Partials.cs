using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailMessageScheduleController
    {
        
        [HttpPost]
        [Route("{id}/force-send")]
        public async Task<IActionResult> ForceSendAsync(Guid id)
        {
            var result = await _appService.ForceSendAsync(id);
            return Ok(result);
        }
    }
}