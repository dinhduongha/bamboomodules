using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ChangePasswordWizardController
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