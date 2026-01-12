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
        [Route("{id}/action-open-journal-entry")]
        public async Task<IActionResult> ActionOpenJournalEntryAsync(Guid id)
        {
            var result = await _appService.OpenJournalEntryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid id)
        {
            var result = await _appService.OpenReferenceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-valuation-at-date")]
        public async Task<IActionResult> ActionValuationAtDateAsync(Guid id)
        {
            var result = await _appService.ValuationAtDateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}