using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ChangePasswordOwnController
    {
        
        [HttpPost]
        [Route("{id}/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(Guid id)
        {
            var result = await _appService.ChangePasswordAsync(id);
            return Ok(result);
        }
    }
}