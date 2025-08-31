using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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