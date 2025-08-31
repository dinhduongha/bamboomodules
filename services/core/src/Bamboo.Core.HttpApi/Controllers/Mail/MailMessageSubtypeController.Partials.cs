using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailMessageSubtypeController
    {
        
        [HttpPost]
        [Route("{id}/default-subtypes")]
        public async Task<IActionResult> DefaultSubtypesAsync(Guid id, [FromBody] MailMessageSubtypeDefaultSubtypesRequestDto input)
        {
            var result = await _appService.DefaultSubtypesAsync(id, input.ModelName);
            return Ok(result);
        }
    }
}