using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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