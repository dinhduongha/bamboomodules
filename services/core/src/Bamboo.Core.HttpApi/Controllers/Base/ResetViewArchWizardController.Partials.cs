using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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