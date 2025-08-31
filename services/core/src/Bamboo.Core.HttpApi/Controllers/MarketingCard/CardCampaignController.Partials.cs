using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MarketingCard
{
    public partial class CardCampaignController
    {
        
        [HttpPost]
        [Route("{id}/action-preview")]
        public async Task<IActionResult> ActionPreviewAsync(Guid id)
        {
            var result = await _appService.PreviewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-share")]
        public async Task<IActionResult> ActionShareAsync(Guid id)
        {
            var result = await _appService.ShareAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-cards")]
        public async Task<IActionResult> ActionViewCardsAsync(Guid id)
        {
            var result = await _appService.ViewCardsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-cards-clicked")]
        public async Task<IActionResult> ActionViewCardsClickedAsync(Guid id)
        {
            var result = await _appService.ViewCardsClickedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-cards-shared")]
        public async Task<IActionResult> ActionViewCardsSharedAsync(Guid id)
        {
            var result = await _appService.ViewCardsSharedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mailings")]
        public async Task<IActionResult> ActionViewMailingsAsync(Guid id)
        {
            var result = await _appService.ViewMailingsAsync(id);
            return Ok(result);
        }
    }
}