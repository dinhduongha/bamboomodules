using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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