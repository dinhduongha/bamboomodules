using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResUsersApikeysDescriptionController
    {
        
        [HttpPost]
        [Route("{id}/check-access-make-key")]
        public async Task<IActionResult> CheckAccessMakeKeyAsync(Guid id)
        {
            var result = await _appService.CheckAccessMakeKeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/make-key")]
        public async Task<IActionResult> MakeKeyAsync(Guid id)
        {
            var result = await _appService.MakeKeyAsync(id);
            return Ok(result);
        }
    }
}