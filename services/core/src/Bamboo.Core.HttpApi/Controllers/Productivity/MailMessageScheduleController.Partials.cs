using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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