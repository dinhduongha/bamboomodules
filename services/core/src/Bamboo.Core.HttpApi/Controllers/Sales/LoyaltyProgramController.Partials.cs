using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class LoyaltyProgramController
    {
        
        [HttpPost]
        [Route("{id}/action-open-loyalty-cards")]
        public async Task<IActionResult> ActionOpenLoyaltyCardsAsync(Guid id)
        {
            var result = await _appService.OpenLoyaltyCardsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-program-share")]
        public async Task<IActionResult> ActionProgramShareAsync(Guid id)
        {
            var result = await _appService.ProgramShareAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-from-template")]
        public async Task<IActionResult> CreateFromTemplateAsync(Guid id, [FromBody] LoyaltyProgramCreateFromTemplateRequestDto input)
        {
            var result = await _appService.CreateFromTemplateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-program-templates")]
        public async Task<IActionResult> GetProgramTemplatesAsync(Guid id)
        {
            var result = await _appService.GetProgramTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}