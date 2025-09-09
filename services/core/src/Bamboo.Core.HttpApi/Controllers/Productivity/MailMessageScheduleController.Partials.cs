using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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