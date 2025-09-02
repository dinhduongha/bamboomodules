using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
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