using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    public partial class MrpUnbuildController
    {
        
        [HttpPost]
        [Route("{id}/action-unbuild")]
        public async Task<IActionResult> ActionUnbuildAsync(Guid id)
        {
            var result = await _appService.UnbuildAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
    }
}