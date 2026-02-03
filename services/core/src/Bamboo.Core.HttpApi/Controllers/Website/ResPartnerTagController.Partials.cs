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
        [Route("get-selection-class")]
        public async Task<IActionResult> GetSelectionClassAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSelectionClassAsync(ids);
            return Ok(result);
        }
    }
}