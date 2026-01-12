using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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