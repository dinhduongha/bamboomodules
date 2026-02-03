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
        [Route("action-open-loyalty-cards")]
        public async Task<IActionResult> ActionOpenLoyaltyCardsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLoyaltyCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-program-share")]
        public async Task<IActionResult> ActionProgramShareAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProgramShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-from-template")]
        public async Task<IActionResult> CreateFromTemplateAsync(LoyaltyProgramCreateFromTemplateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-program-templates")]
        public async Task<IActionResult> GetProgramTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetProgramTemplatesAsync(ids);
            return Ok(result);
        }
    }
}