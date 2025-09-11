using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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