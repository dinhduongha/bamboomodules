using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockValuationLayerController
    {
        
        [HttpPost]
        [Route("action-open-journal-entry")]
        public async Task<IActionResult> ActionOpenJournalEntryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenJournalEntryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenReferenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-valuation-at-date")]
        public async Task<IActionResult> ActionValuationAtDateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValuationAtDateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
}