using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResetViewArchWizardController
    {
        
        [HttpPost]
        [Route("{id}/reset-view-button")]
        public async Task<IActionResult> ResetViewButtonAsync(Guid id)
        {
            var result = await _appService.ResetViewButtonAsync(id);
            return Ok(result);
        }
    }
}