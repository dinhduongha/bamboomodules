using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
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