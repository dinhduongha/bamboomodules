using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAnalyticDistributionModelController
    {
        
        [HttpPost]
        [Route("{id}/action-read-distribution-model")]
        public async Task<IActionResult> ActionReadDistributionModelAsync(Guid id)
        {
            var result = await _appService.ReadDistributionModelAsync(id);
            return Ok(result);
        }
    }
}