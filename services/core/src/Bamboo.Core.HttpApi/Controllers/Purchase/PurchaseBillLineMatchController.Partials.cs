using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    public partial class PurchaseBillLineMatchController
    {
        
        [HttpPost]
        [Route("{id}/action-add-to-po")]
        public async Task<IActionResult> ActionAddToPoAsync(Guid id)
        {
            var result = await _appService.AddToPoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-match-lines")]
        public async Task<IActionResult> ActionMatchLinesAsync(Guid id)
        {
            var result = await _appService.MatchLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-line")]
        public async Task<IActionResult> ActionOpenLineAsync(Guid id)
        {
            var result = await _appService.OpenLineAsync(id);
            return Ok(result);
        }
    }
}