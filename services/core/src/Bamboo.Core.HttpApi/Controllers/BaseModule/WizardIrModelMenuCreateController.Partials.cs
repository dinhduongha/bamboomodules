using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class WizardIrModelMenuCreateController
    {
        
        [HttpPost]
        [Route("{id}/menu-create")]
        public async Task<IActionResult> MenuCreateAsync(Guid id)
        {
            var result = await _appService.MenuCreateAsync(id);
            return Ok(result);
        }
    }
}