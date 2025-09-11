using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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