using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CardCampaignController
    {
        
        [HttpPost]
        [Route("action-preview")]
        public async Task<IActionResult> ActionPreviewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-share")]
        public async Task<IActionResult> ActionShareAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards")]
        public async Task<IActionResult> ActionViewCardsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards-clicked")]
        public async Task<IActionResult> ActionViewCardsClickedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewCardsClickedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards-shared")]
        public async Task<IActionResult> ActionViewCardsSharedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewCardsSharedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailings")]
        public async Task<IActionResult> ActionViewMailingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMailingsAsync(ids);
            return Ok(result);
        }
    }
}