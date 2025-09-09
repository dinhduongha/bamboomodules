using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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