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
        [Route("default-subtypes")]
        public async Task<IActionResult> DefaultSubtypesAsync(MailMessageSubtypeDefaultSubtypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DefaultSubtypesAsync(input);
            return Ok(result);
        }
    }
}