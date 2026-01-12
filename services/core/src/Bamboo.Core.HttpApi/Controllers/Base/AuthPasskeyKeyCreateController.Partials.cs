using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AuthPasskeyKeyCreateController
    {
        
        [HttpPost]
        [Route("{id}/make-key")]
        public async Task<IActionResult> MakeKeyAsync(Guid id, [FromBody] AuthPasskeyKeyCreateMakeKeyRequestDto input)
        {
            var result = await _appService.MakeKeyAsync(id, input);
            return Ok(result);
        }
    }
}