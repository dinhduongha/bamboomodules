using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PurchaseBillLineMatchController
    {
        
        [HttpPost]
        [Route("action-add-to-po")]
        public async Task<IActionResult> ActionAddToPoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-match-lines")]
        public async Task<IActionResult> ActionMatchLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MatchLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-line")]
        public async Task<IActionResult> ActionOpenLineAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLineAsync(ids);
            return Ok(result);
        }
    }
}