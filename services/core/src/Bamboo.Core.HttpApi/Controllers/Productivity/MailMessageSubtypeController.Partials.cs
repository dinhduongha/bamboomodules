using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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