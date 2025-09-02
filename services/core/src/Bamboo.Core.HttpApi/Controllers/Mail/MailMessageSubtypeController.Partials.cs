using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailMessageSubtypeController
    {
        
        [HttpPost]
        [Route("{id}/default-subtypes")]
        public async Task<IActionResult> DefaultSubtypesAsync(Guid id, [FromBody] MailMessageSubtypeDefaultSubtypesRequestDto input)
        {
            var result = await _appService.DefaultSubtypesAsync(id, input);
            return Ok(result);
        }
    }
}