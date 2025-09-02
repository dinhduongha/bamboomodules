using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
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