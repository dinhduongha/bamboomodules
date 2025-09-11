using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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