using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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