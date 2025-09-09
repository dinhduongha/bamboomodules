using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotp
{
    public partial class AuthTotpDeviceController
    {
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var result = await _appService.RemoveAsync(id);
            return Ok(result);
        }
    }
}