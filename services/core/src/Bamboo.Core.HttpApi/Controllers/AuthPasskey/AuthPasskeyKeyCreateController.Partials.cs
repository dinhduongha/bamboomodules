using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    public partial class AuthPasskeyKeyCreateController
    {
        
        [HttpPost]
        [Route("{id}/make-key")]
        public async Task<IActionResult> MakeKeyAsync(Guid id, [FromBody] AuthPasskeyKeyCreateMakeKeyRequestDto input)
        {
            var result = await _appService.MakeKeyAsync(id, input.Registration);
            return Ok(result);
        }
    }
}