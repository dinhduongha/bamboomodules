using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventSponsorController
    {
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
    }
}