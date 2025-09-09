using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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