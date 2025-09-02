using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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