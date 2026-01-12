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
        [Route("{id}/action-talent-pool-add-talents")]
        public async Task<IActionResult> ActionTalentPoolAddTalentsAsync(Guid id)
        {
            var result = await _appService.TalentPoolAddTalentsAsync(id);
            return Ok(result);
        }
    }
}