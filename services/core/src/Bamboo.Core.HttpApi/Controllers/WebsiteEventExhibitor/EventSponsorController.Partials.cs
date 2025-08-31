using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventExhibitor
{
    public partial class EventSponsorController
    {
        
        [HttpPost]
        [Route("{id}/get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid id)
        {
            var result = await _appService.GetBackendMenuIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteUrlAsync(id);
            return Ok(result);
        }
    }
}