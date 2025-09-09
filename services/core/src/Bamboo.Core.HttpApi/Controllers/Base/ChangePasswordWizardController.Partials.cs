using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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