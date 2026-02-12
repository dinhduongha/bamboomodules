using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpController
    {
        protected readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-preview")]
        public async Task<IActionResult> PreviewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-share")]
        public async Task<IActionResult> ShareAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards")]
        public async Task<IActionResult> ViewCardsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards-clicked")]
        public async Task<IActionResult> ViewCardsClickedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewCardsClickedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-cards-shared")]
        public async Task<IActionResult> ViewCardsSharedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewCardsSharedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailings")]
        public async Task<IActionResult> ViewMailingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMailingsAsync(ids);
            return Ok(result);
        }
    }
    
}