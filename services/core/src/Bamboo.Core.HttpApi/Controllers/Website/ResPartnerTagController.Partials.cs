using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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