using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ChangePasswordUserController
    {
        
        [HttpPost]
        [Route("{id}/change-password-button")]
        public async Task<IActionResult> ChangePasswordButtonAsync(Guid id)
        {
            var result = await _appService.ChangePasswordButtonAsync(id);
            return Ok(result);
        }
    }
}