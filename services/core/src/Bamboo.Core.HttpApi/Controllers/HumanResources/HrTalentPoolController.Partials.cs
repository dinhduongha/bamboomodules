using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrTalentPoolController
    {
        
        [HttpPost]
        [Route("action-talent-pool-add-talents")]
        public async Task<IActionResult> ActionTalentPoolAddTalentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TalentPoolAddTalentsAsync(ids);
            return Ok(result);
        }
    }
}