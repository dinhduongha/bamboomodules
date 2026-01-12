using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResPartnerTagController
    {
        
        [HttpPost]
        [Route("{id}/get-selection-class")]
        public async Task<IActionResult> GetSelectionClassAsync(Guid id)
        {
            var result = await _appService.GetSelectionClassAsync(id);
            return Ok(result);
        }
    }
}